using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Galeria system/ Galeria Item")]
public class GaleriaScrip : ScriptableObject
{
    public int ID;
    public string NameOfAnimal;
    [TextArea(4,4)]
    public string DescriptionOfAnimal;
    public Sprite Imagen;
    public int MaxNumeroFotos;
}
