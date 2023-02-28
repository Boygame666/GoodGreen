using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausaMenu : MonoBehaviour
{
    private bool active;
    /// <summary>
    /// referencia al canvas que estamos utlizando
    /// </summary>
    Canvas canvas;
    public MenuOpciones opciones;
    private void Start()
    {
        //lo llamamos y al iniciarse esta desactivado
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    private void Update()
    {
        Pausa();
        
    }
    void Pausa()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Tab))
        {
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
            opciones.GetComponent<Canvas>().enabled = false;

        }

    }


}
