using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class AnimalScript : MonoBehaviour
{    

    /// <summary>
    /// booleano que gestiona la activación de los triggers del mapa
    /// </summary>
    public bool trigger;
    public GameObject Animal;
    
    public Transform Es;
    public PlayerController PC;
    public CambioCamara CC;
    private PhotoController PH;
    private CursorController controls;

    public Camera cam;

    private void Awake()
    {
        controls = new CursorController(); 
        cam = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Start()
    {
        controls.Mouse.Click.started += _ =>StardedClick();
        controls.Mouse.Click.performed += _ =>EndClick();
    }

    private void StardedClick()
    {
        controls.Enable();
    }
    private void EndClick()
    {
        ClickAnimal();
        controls.Disable();
    }


    void ClickAnimal()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if(hit2D.collider != null)
        {
            trigger = true;
        }
        else
            trigger = false;

        RaycastHit2D[] Hits2Dall = Physics2D.GetRayIntersectionAll(ray);
        for(int i = 0; i < Hits2Dall.Length; ++i) 
        {
            if (Hits2Dall[i].collider != null)
            {
                if(hit2D.collider.tag == "Animal")
                {
                    //cam.transform.position = new Vector3(Es.transform.position.x, Es.transform.position.y, -1);
                    Animal.GetComponent<PhotoController>().EscenaAnimal();
                    CC.ListaDeCamaras[1].gameObject.SetActive(true);
                    CC.ListaDeCamaras[0].gameObject.SetActive(false);
                    CC.ListaDeCamaras[1].transform.position = new Vector3(Es.transform.position.x, Es.transform.position.y, -1);
                    //CC.GetComponent<CambioCamara>().ActivarCamara(1);
                }
                if (hit2D.collider.tag == "BackAnimal")
                {
                    //hit2D.collider.gameObject.GetComponent<PhotoController>().EscenaBackAnimal();
                    Animal.GetComponent<PhotoController>().EscenaBackAnimal();
                    CC.ListaDeCamaras[1].gameObject.SetActive(false);
                    CC.ListaDeCamaras[0].gameObject.SetActive(true);
                    //CC.ListaDeCamaras[0].gameObject.SetActive(true);

                }
            }

        }


    }

}
