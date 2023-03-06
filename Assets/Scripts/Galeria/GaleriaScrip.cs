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
    public Texture2D ImagenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    public Sprite Imagen ;
    public SpriteRenderer imagen;
    public int MaxNumeroFotos;
   
    void Update()
    {     
        Sprite photoSprite = Sprite.Create(ImagenTexture, new Rect(0.0f, 0.0f, ImagenTexture.width, ImagenTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        //pone ese sprite en la foto ingame
        imagen.sprite = photoSprite;
    }


}
