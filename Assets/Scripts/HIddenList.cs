using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIddenList : MonoBehaviour
{
    public bool DontHide;
    public HIddenObject hidden;
    void Start()
    {
        hidden.Add(gameObject);

        if (gameObject.TryGetComponent(out Renderer renderer) && !DontHide)
            renderer.enabled = false;

        if (gameObject.TryGetComponent(out Light Light) && !DontHide)
            Light.enabled = false;

    }
}
