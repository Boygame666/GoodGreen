using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class CamaraZoom : MonoBehaviour
{
    public Camera Camera;
    [SerializeField] float Zoom, ZoomMin, ZoomMax;

    [SerializeField]
    private SpriteRenderer Background;

    private float FotoMinX, FotoMaxX, FotoMinY, FotoMaxY;

    // Update is called once per frame
    void Update()
    {
        FotoMinX = Background.transform.position.x - Background.bounds.size.x;
        FotoMaxX = Background.transform.position.x + Background.bounds.size.x;

        FotoMinY = Background.transform.position.y - Background.bounds.size.y;
        FotoMaxY = Background.transform.position.y + Background.bounds.size.y;

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
