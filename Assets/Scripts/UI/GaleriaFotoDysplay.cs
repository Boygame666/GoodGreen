using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class GaleriaFotoDysplay : MonoBehaviour
{
    [SerializeField] GaleriaFoto galeriaFotoItem;
    protected GaleriaSystem galeriaSystem;
    protected Dictionary<GaleriaSlot_UI, GaleriaSlots> slotDictionary;
    public GaleriaSystem GaleriaSystem => galeriaSystem;
    public Dictionary<GaleriaSlot_UI, GaleriaSlots> SlotDictionary => slotDictionary;

    public abstract void AssigSlot(GaleriaSystem InvToDisplay);

    protected virtual void UpdateSlot(GaleriaSlots UpdateSlot)
    {
        foreach(var slot in slotDictionary)
        {
            if(slot.Value == UpdateSlot)
            {
                slot.Key.UpdateSlot(UpdateSlot);
            }
        }
    }
}
