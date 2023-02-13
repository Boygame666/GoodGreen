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
    /// textura en la que se guarda la captura de pantalla
    /// </summary>
    Texture2D screenCapture;
    public bool final;
    [SerializeField] GameObject black;



    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        photoAnimator = photo.GetComponent<Animator>();
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        imagen = photo.GetComponent<SpriteRenderer>();

        final = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            //cancela la animación actual
            photoAnimator.Play("None");


            //usa una corrutina para accionar todo el mecanismo de la foto

        }

    }
    /// <summary>
    /// captura la pantalla
    /// </summary>
    /// <returns></returns>
    public IEnumerator CapturePhoto()
    {
        //pone la pantalla en blanco
        flash.color = Color.white;
        if (final)
        {
            black.SetActive(true);
        }

        yield return new WaitForEndOfFrame();

        //crea un rectangulo y lee cada pixel de pantalla para pintarlo en él
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

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
