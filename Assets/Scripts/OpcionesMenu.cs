using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesMenu : MonoBehaviour
{
    private bool active;
    Canvas canvas;
    PlayerController PC;

    private void Start()
    {

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Y)|| Input.GetKeyDown(KeyCode.Tab))
        {
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;

        }
    }
}
