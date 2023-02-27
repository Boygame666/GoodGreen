using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.UIElements;

[System.Serializable]
public class GaleriaSystem 
{
    [SerializeField] private List<GaleriaSlots> galeriaslots;

    public List<GaleriaSlots> galeriaSlots => galeriaslots;

    public int galeriaSize => galeriaSlots.Count;

    public UnityAction<GaleriaSlots> ONGaleriaSlotChange;

    public GaleriaSystem(int Size)
    {
        galeriaslots= new List<GaleriaSlots>(Size);

        for(int i =0; i < Size; i++)
        {
            galeriaslots.Add(new GaleriaSlots());
        }
    }
    public bool AddToInventory(GaleriaScrip FotoToAdd,int amountToAdd)
    {
        //galeriaslots[0] = new GaleriaSlots(FotoToAdd, amountToAdd);
        //return true;
        if(ContainFoto(FotoToAdd,out List<GaleriaSlots> galSlot))
        {
            foreach(var slot in galSlot)
            {
                if (slot.RoomLeftForFoto(amountToAdd))
                {
                    slot.AddToSpace(amountToAdd);
                    ONGaleriaSlotChange?.Invoke(slot);
                    return true;
                }
            }

        }
        
        
        if(HasfreeSlot(out GaleriaSlots freeslot))
        {
            freeslot.UpdateGaleriaSlot(FotoToAdd,amountToAdd);
            ONGaleriaSlotChange?.Invoke(freeslot);
            return true;
        }
        return false;
    }
    public bool ContainFoto(GaleriaScrip FotoToAdd, out List<GaleriaSlots> galSlot)
    {
        galSlot = galeriaSlots.Where(i => i.galeriaFoto == FotoToAdd).ToList();
        Debug.Log("pillado");
        return galSlot == null? false: true;
        //galeriaSlots.First(slot => slot.galeriaFoto.MaxNumeroFotos > 5);
    }
    public bool HasfreeSlot(out GaleriaSlots freeslot)
    {
        freeslot = galeriaslots.FirstOrDefault(i => i.galeriaFoto == null);
        return freeslot == null ? false : true;
    }
}
