using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GaleriaSlots 
{
    //Aqui creamos lo que se guardaria en cada slot de la galeria
    [SerializeField] private GaleriaScrip GaleriaFoto;
    [SerializeField] private int MaxNumGaleriaFoto;

    public GaleriaScrip galeriaFoto => GaleriaFoto;
    public int maxNumGaleriaFotos => MaxNumGaleriaFoto;

    public GaleriaSlots(GaleriaScrip source, int amount)
    {
        GaleriaFoto = source;
        MaxNumGaleriaFoto = amount;
    }
    public GaleriaSlots()
    {
        clearSpace();
    }
    public void clearSpace()
    {
        GaleriaFoto = null;

        MaxNumGaleriaFoto = -1;

    }
    //se chequea que hay espacio para poder guardar mas fotos
    public bool RoomLeftForFoto(int amountToAdd, out int amountToLeft)
    {
        amountToLeft = GaleriaFoto.MaxNumeroFotos - maxNumGaleriaFotos;
        return RoomLeftForFoto(amountToAdd);
    }
    public bool RoomLeftForFoto(int amountToAdd)
    {
        if (maxNumGaleriaFotos + amountToAdd <= GaleriaFoto.MaxNumeroFotos) return true; 
        else return false;
    }
    public void AddToSpace(int amount)
    {
        MaxNumGaleriaFoto += amount;
    }
    public void RemoveFromSpace(int amount)
    {
        MaxNumGaleriaFoto -= amount;
    }
  
}
