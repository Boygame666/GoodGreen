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

    GameObject animal;

    CambioScene CS;

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
        Console.WriteLine("2D collider");
    }
    private void EndClick()
    {
        ClickAnimal();
    }


    void ClickAnimal()
    {
        Ray ray = cam.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());

        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if(hit2D.collider != null)
        {
            trigger = true;
        }
        else
            trigger = false;

        if (hit2D.collider != null && trigger == true){

            animal = null;
            animal = hit2D.transform.gameObject;
            

            if (animal.CompareTag("Animal"))
            {
                CS.LoadScene();
            }


        }
        if(animal != null)
        {
            animal = null;
        }



    }

}
