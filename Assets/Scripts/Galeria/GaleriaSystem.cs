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
}
