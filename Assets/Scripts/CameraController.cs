using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    private Vector3 Player_Pos;

    public float MiraDelante;
    public float Smoothing;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Player_Pos = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        DireccionPlayer();
   
    }

    void DireccionPlayer()
    {
        //Teniendo en cuenta donde mira el usuario la camara se movera en esa dirreccion y volvera de nuevo al jugador
        if(Player.transform.localScale.x ==  1)
        {
            Player_Pos = new Vector3(Player_Pos.x + MiraDelante, transform.position.y,transform.position.z);    
        }
        if (Player.transform.localScale.x == -1)
        {
            Player_Pos = new Vector3(Player_Pos.x - MiraDelante, transform.position.y, transform.position.z);
        }

        //Codigo para cuando se hace el mov en dicha direccion sea mas fluido y no forzado
        transform.position = Vector3.Lerp(transform.position,Player_Pos, Smoothing * Time.deltaTime);
    }

}
