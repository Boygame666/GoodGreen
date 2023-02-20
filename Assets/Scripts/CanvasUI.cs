using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject Pausa;
    public GameObject Ajustes;
    public GameObject Galeria;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(false);
        Ajustes.SetActive(false);
        Galeria.SetActive(false);

        panel.SetActive(true);
    }
}
