using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Player_Pos;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player_Pos;
        Player_Pos = new Vector3(Player.transform.position.x, -8 , 1);
    }
}
