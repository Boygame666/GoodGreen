using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraZoom : MonoBehaviour
{
    [SerializeField] float sensibilidad;
    [SerializeField] float ZoomMin;
    [SerializeField] float ZoomMax;

    public bool ZoomActive;

    public Vector3[] Traget;


    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    { 
        Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(ZoomActive) { }
    }
}
