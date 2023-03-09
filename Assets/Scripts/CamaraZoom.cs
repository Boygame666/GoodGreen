using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraZoom : MonoBehaviour
{
    public float ZoomOut ;


    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    { 
        Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.fieldOfView = ZoomOut;
    }
    public void ZoomMovement(float Zoom)
    {
        ZoomOut = Zoom;
    }
}
