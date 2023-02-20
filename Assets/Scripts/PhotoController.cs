using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;
using Unity.VisualScripting;

public class PhotoController : MonoBehaviour
{
    /// <summary>
    /// dimensiones que tendrá la zona en la que se muestre la foto
    /// </summary>
    [SerializeField] private Image photoDisplayArea;
    /// <summary>
    /// imagen en blanco que cambia su transparencia para simular el flash
    /// </summary>
    public RawImage flash;
    /// <summary>
    /// objeto físico de la foto dentro del juego
    /// </summary>
    public GameObject photo;
    /// <summary>
    /// lista de objetos ocultos a mostrar
    /// </summary>
    public HIddenObject hidden;
    /// <summary>
    /// renderizador de sprites adjunto al objeto foto para mostrar la imagen como sprite
    /// </summary>
    private SpriteRenderer imagen;
    /// <summary>
    /// referencia a la cámara de la cámara física
    /// </summary>
    public Camera cameraCamera;
    /// <summary>
    /// componente animator de la foto física
    /// </summary>
    public Animator photoAnimator;
    /// <summary>
    /// velocidad de disi´pación del flash
    /// </summary>
    public float flashSpeed;
    /// <summary>
    /// booleano de gestión de tiempo en que se muestra la foto
    /// </summary>
    public bool showing;
    /// <summary>
    /// booleano de gestión de cooldown del flash
    /// </summary>
    public bool flashReady;
    /// <summary>
    /// booleano que indica cuando el jugador no ve
    /// </summary>
    public bool flashed;
    /// <summary>
    /// booleano para indicar que estamos en la escena del animal
    /// </summary>
    public bool EsceneAnimal;
    /// <summary>
    /// textura en la que se guarda la captura de pantalla
    /// </summary>
    Texture2D screenCapture;



    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        flashReady = true;
        showing = false;
        photoAnimator = photo.GetComponent<Animator>();
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        imagen = photo.GetComponent<SpriteRenderer>();
        EsceneAnimal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && flashReady&&EsceneAnimal)
        {
            //cancela la animación actual
            photoAnimator.Play("Empty");
            flashReady = false;
            StartCoroutine(CapturePhoto());


            //usa una corrutina para accionar todo el mecanismo de la foto

        }

    }
    public void EscenaAnimal()
    {
        EsceneAnimal= true;
    }
    public void EscenaBackAnimal()
    {
        EsceneAnimal = false;
    }
    /// <summary>
    /// maneja el efecto de flash
    /// </summary>
    /// <returns></returns>
    IEnumerator FlashCoroutine()
    {
        flashed = true;
        //esconde los objetos clave
        hidden.hide();

        timer = 0f;

        //disipa el flash lentamente
        while (timer < 4f)
        {
            //efecto de disipacion
            flash.color = Color.Lerp(flash.color, Color.clear, flashSpeed * Time.deltaTime);

            timer += Time.deltaTime;

            if (timer > 0.1f && flashed)
            {
                flashed = false;

            }


            //eventualmente muestra la foto
            else if (timer > 1f && !showing)
            {

                photoAnimator.Play("FotoAnim");
                showing = true;

            }
            else if (timer > 4f)
                flashReady = true;



            //Debug.Log(timer);

            yield return null;

        }
        //devuelve al color transparente la pantalla
        flash.color = Color.clear;

        showing = false;


        yield break;
    }
    /// <summary>
    /// captura la pantalla
    /// </summary>
    /// <returns></returns>
    public IEnumerator CapturePhoto()
    {
        //pone la pantalla en blanco
        flash.color = Color.white;

        hidden.hide();

        yield return new WaitForEndOfFrame();

        //crea un rectangulo y lee cada pixel de pantalla para pintarlo en él
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        //screenCapture.ReadPixels(regionToRead, 0, 0, false);
        //screenCapture.Apply();

        //crea textura a partir de una render texture de la camara
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        cameraCamera.targetTexture = rt;
        cameraCamera.Render();
        RenderTexture.active = rt;
        //lee los pixeles
        screenCapture.ReadPixels(regionToRead, 0, 0);
        screenCapture.Apply();

        //borra el resto de datos innecesarios
        cameraCamera.targetTexture = null;
        RenderTexture.active = null; // added to avoid errors 
        DestroyImmediate(rt);

        //inicia la corrutina del flash
        StartCoroutine(FlashCoroutine());

        //muestra la foto
        if (!showing)
            ShowPhoto();

    }

    /// <summary>
    /// muestra la foto
    /// </summary>
    void ShowPhoto()
    {
        //toma la captura de pantalla y la aplica a un sprite
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        //pone ese sprite en la foto ingame
        imagen.sprite = photoSprite;

    }
}
