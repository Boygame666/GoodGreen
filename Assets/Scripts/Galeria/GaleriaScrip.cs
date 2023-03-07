using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Galeria system/ Galeria Item")]
public class GaleriaScrip : ScriptableObject
{
    //datos que tendran cada uno de nuestros scripteable objects
    public int ID;
    public string NameOfAnimal;
    [TextArea(4,4)]
    public string DescriptionOfAnimal;
    public event Action SpriteChanged;
    //public Texture2D ImagenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    [SerializeField]public Sprite Imagen ;
    //public SpriteRenderer imagen ;
    public int MaxNumeroFotos;
   
    public Sprite Sprite
    {
        get { return Imagen; }
        set
        {
            if (Imagen == value)
                return;
            Imagen = value;
            SpriteChanged?.Invoke();

        }
    }


}
