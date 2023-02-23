using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionTrigger : MonoBehaviour
{
    [SerializeField] GameObject BoxTrigger;
    public GameObject Golondrina;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Golondrina.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BoxTrigger != null)
            BoxTrigger.SetActive(true);

        if (collision.CompareTag("Player"))
        {
            Golondrina.SetActive(true);
            Destroy(BoxTrigger);
            
        }


    }

}
