using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadious = 1f;
    public GaleriaScrip galeriaObject;

    private BoxCollider2D myCollider;

    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger= true;
        myCollider.edgeRadius = PickUpRadious;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var Inventory = other.transform.GetComponent<GaleriaHolder>();
        if (!Inventory) return;

        if (Inventory.GaleriaSystem.AddToInventory(galeriaObject, 1))
        {
            Debug.Log("pillado");
        }
    }
}
