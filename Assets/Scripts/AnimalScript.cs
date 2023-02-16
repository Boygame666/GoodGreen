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

        RaycastHit2D[] Hits2DallNonAlloc = new RaycastHit2D[1];
        int numberOfHits = Physics2D.GetRayIntersectionNonAlloc(ray, Hits2DallNonAlloc);
        for(int i = 0; i < Hits2DallNonAlloc.Length; ++i) 
        {
            if (Hits2DallNonAlloc[i].collider != null)
            {
                if(hit2D.collider.tag == "Animal")
                {                                     
                    cam.transform.position = new Vector3(Es.transform.position.x, Es.transform.position.y, -1);
                    PC.transform.position = new Vector3(Es.transform.position.x, transform.position.y, transform.position.z);
                    Animal.GetComponent<PhotoController>().EscenaAnimal();
                }
                if (hit2D.collider.tag == "BackAnimal")
                {
                    Animal.GetComponent<PhotoController>().EscenaBackAnimal();

                }
            }

        }


    }

}
