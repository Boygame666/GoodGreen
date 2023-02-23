using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject[] ListaDeCamaras;
    public int Ncamara;

    void Start()
    {
        ActivarCamara();
    }
    public void ActivarCamara()
    {
        for(int  i = 0;i < Ncamara;i++)
        {
            ListaDeCamaras[i].gameObject.SetActive(false);
        }
        ListaDeCamaras[0].gameObject.SetActive(true);
    }
}
