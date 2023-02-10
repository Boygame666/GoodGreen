using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    float x;

    public float speed = 12f;
    public Transform Player;
    private Vector3 Scale;
    private Vector3 MousePosition;

    PausaMenu PM;


    Animator anim;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PM= GetComponent<PausaMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
        fixScale();
        //ClickPlayer();
        

    }

    void MovementPlayer()
    {
        x = Input.GetAxis("Horizontal");

        //crea el movimiento
        Vector2 move = Player.position;

        move = move + new Vector2(x, 0f) * speed * Time.deltaTime;

        Player.position = move;


    }
    //void ClickPlayer()
    //{
    //    //busca en el escenario(background) donde hemos hecho click  
    //    MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //establece la posicion z a 0 para no modificar la profundidad
    //    MousePosition.z = 0f;
    //    //establece la posicion y a 0 para no modificar la profundidad
    //    MousePosition.y = 0f;

    //    if (Input.GetMouseButtonDown(0))//el juego detecta cuando hacemos click izq
    //    {
    //        // ahora movemos el objeto hacia el punto que hemos clicado con una velocidad definida
    //        Player.position = Vector3.MoveTowards(Player.position, MousePosition, speed * Time.deltaTime);
    //    }
    //}
    void fixScale()
    {

        if (Input.GetKey(KeyCode.D))
        {
            Scale = new Vector3(1, 1, 1);
            Player.localScale = Scale;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Scale = new Vector3(-1, 1, 1);
            Player.localScale = Scale;

        }

    }
}
