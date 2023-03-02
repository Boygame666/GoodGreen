using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GaleriaFoto : MonoBehaviour
{
    public Image FotoSprite;

    private void Awake()
    {
        FotoSprite.color = Color.clear;
    }
}
