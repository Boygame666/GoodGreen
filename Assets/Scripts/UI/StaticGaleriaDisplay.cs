using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGaleriaDisplay : GaleriaFotoDysplay
{
    [SerializeField] private GaleriaHolder galeriaHolder;
    [SerializeField] private GaleriaSlot_UI[] slot;
    protected override void Start()
    {
        base.Start();

        if(galeriaHolder != null)
        {
            galeriaSystem = galeriaHolder.GaleriaSystem;
            galeriaSystem.ONGaleriaSlotChange += UpdateSlot;
        }

        AssigSlot(galeriaSystem);
    }
    public override void AssigSlot(GaleriaSystem InvToDisplay)
    {
        slotDictionary = new Dictionary<GaleriaSlot_UI, GaleriaSlots>();

        if (slot.Length != galeriaSystem.galeriaSize) Debug.Log("Galeria slot fuera de sincro");
        for(int i = 0; i < galeriaSystem.galeriaSize; i++)
        {
            slotDictionary.Add(slot[i], galeriaSystem.galeriaSlots[i]);
            slot[i].Init(galeriaSystem.galeriaSlots[i]);
        }
    }

}
