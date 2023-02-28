using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    private bool active;
    /// <summary>
    /// referencia al canvas que estamos utlizando
    /// </summary>
    Canvas canvas;
    private bool juegoPausado = false;

    private void Start()
    {
        //lo llamamos y al iniciarse esta desactivado
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }
    public void Configuracion()
    {
        //Se activa cuando llaman a configuracion
        canvas.enabled = true;
        juegoPausado=true;
        Time.timeScale = 0f;

    }
    public void Volver()
    {
        //Se desactiva y muestra el canvas anterior
        canvas.enabled = false;
        juegoPausado= true;
        Time.timeScale = 0f;
    }
}
