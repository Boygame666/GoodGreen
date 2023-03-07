using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadious = 1f;
    public GaleriaScrip galeriaObject;

    private BoxCollider2D myCollider;

    public GaleriaScrip spriteObject;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger= true;
        myCollider.edgeRadius = PickUpRadious;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteObject != null)
        {
            //spriteRenderer.sprite = spriteObject.Sprite;
            spriteObject.Sprite = spriteRenderer.sprite;
            spriteObject.SpriteChanged += HandleSpriteChanged;
        }
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
    private void HandleSpriteChanged()
    {
        spriteObject.Sprite = spriteRenderer.sprite;
    }
}
