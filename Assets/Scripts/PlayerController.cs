using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float x;

    public float speed = 12f;
    public Transform Player;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }

    void MovementPlayer()
    {
        x = Input.GetAxis("Horizontal");

        //crea el movimiento
        Vector2 move = Player.position;

        move = move + new Vector2(x, 0f) * speed * Time.deltaTime;

        Player.position = move;
    }
}
