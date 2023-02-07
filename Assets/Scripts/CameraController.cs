using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    private Vector3 Player_Pos;

    public float MiraDelante;

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
        if(Player.transform.localScale.x ==  1)
        {
            Player_Pos = new Vector3(Player_Pos.x + MiraDelante, transform.position.y,transform.position.z);    
        }
        if (Player.transform.localScale.x == -1)
        {
            Player_Pos = new Vector3(Player_Pos.x - MiraDelante, transform.position.y, transform.position.z);
        }

        transform.position = Player_Pos;
    }

}
