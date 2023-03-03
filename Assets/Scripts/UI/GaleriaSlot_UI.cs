using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GaleriaSlot_UI : MonoBehaviour
{
    [SerializeField] private Image FotoSprite;
    [SerializeField] private GaleriaSlots assinedSlot;

    private Button button;

    public GaleriaSlots AssinedSlot => assinedSlot;

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }
    public void Init(GaleriaSlots slot)
    {
        assinedSlot = slot;
        UpdateSlot(slot);
    }
    public void UpdateSlot(GaleriaSlots slot)
    {
        if(slot.galeriaFoto != null) 
        { 
            FotoSprite.sprite = slot.galeriaFoto.Imagen;
            FotoSprite.color = Color.white; 

        }
        else
        {
            ClearSlot();
        }
    }
    public void UpdateSlot()
    {
        if (assinedSlot != null)
        {
            UpdateSlot(assinedSlot);
        }
    }
    public void ClearSlot()
    {
        assinedSlot?.clearSpace();
        FotoSprite.sprite = null;
        FotoSprite.color = Color.clear;
    }
    public void OnUISlotClick()
    {

    }
}
