using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class CamaraZoom : MonoBehaviour
{
    public Camera Camera;
    [SerializeField] float Zoom;
    [SerializeField] float ZoomMin;
    [SerializeField] float ZoomMax;


    // Update is called once per frame
    void Update()
    {

        limiteZoom();

    }
    public void limiteZoom()
    {
        if (Camera.orthographicSize >= ZoomMax && Camera.orthographicSize <= ZoomMin)
        {
            if (Camera.orthographic)
            {
                Camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Zoom;
            }
            else
            {
                Camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * Zoom;
            }
        }
        else
        {
            if (Camera.orthographicSize >= ZoomMin)
            {
                Camera.orthographicSize = ZoomMin;

            }
            if (Camera.orthographicSize <= ZoomMax)
            {
                Camera.orthographicSize = ZoomMax;
            }


        }
    }
}
