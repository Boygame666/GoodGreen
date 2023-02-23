using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject[] ListaDeCamaras;
    public int Ncamara;

    void Start()
    {
        ActivarCamara(0);
    }
    public void ActivarCamara(int i)
    {
        for( i = 0;i < Ncamara;i++)
        {
            ListaDeCamaras[i].gameObject.SetActive(false);
        }
        ListaDeCamaras[0].gameObject.SetActive(true);
    }
}
