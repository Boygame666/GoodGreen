using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GaleriaHolder : MonoBehaviour
{
    [SerializeField] private int Galeriasize;
    [SerializeField] protected GaleriaSystem galeriaSystem;

    public GaleriaSystem GaleriaSystem => galeriaSystem;

    public static UnityAction<GaleriaSystem> OnDianamicGaleriaDispalyRequest;


    private void Awake()
    {
        galeriaSystem = new GaleriaSystem(Galeriasize);
    }
}
