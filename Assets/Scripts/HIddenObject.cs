using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIddenObject : MonoBehaviour
{
    /// <summary>
    /// referencia al objeto foto fisica
    /// </summary>
    public GameObject photo;
    /// <summary>
    /// componente renderer del objeto oculto
    /// </summary>
    private Renderer rend;

    private Light lit;
    /// <summary>
    /// referencia a la lista de objetos ocultos y a ocultar
    /// </summary>
    public List<GameObject> hiddenList = new List<GameObject>();

    private bool hidden;

    public void Start()
    {
        hidden = true;
    }
    /// <summary>
    /// esconde todos  y revela los objetos según conviene
    /// </summary>
    public void hide()
    {
        //para cada objeto en la lista si es visible lo esconde, si es solido lo transparenta y viceversa
        foreach (GameObject go in hiddenList)
        {
            if (go != null)
            {
                //toma los componentes renderer y collider de los objetos para alternarlos
                if (go.TryGetComponent<Renderer>(out rend))
                {
                    rend = go.GetComponentInChildren<Renderer>();

                    //alterna los componentes
                    if (rend.enabled == false)
                        rend.enabled = true;
                    else
                        rend.enabled = false;
                }


                if (go.TryGetComponent<Light>(out lit))
                {
                    lit = go.GetComponentInChildren<Light>();

                    //alterna los componentes
                    if (lit.enabled == false)
                        lit.enabled = true;
                    else
                        lit.enabled = false;

                }


                //alterna los componentes
            }


        }
        hidden = !hidden;
        //muestra las pertenencias
        photo.GetComponent<Renderer>().enabled = hidden;




    }
    /// <summary>
    /// añade a la lista de objetos a esconder
    /// </summary>
    /// <param name="go"></param>


    public void Add(GameObject go)
    {
        hiddenList.Add(go);
    }
}
