using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    //Indicamos en la escena el nombre de la escena a la cual queremos cambiar
    private int NextScene;

    private void Start()
    {
        NextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
