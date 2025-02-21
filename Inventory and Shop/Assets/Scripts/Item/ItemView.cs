using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public ItemProperty itemProperty;
    [SerializeField] private Image itemImage;
    [SerializeField] public TextMeshProUGUI quantity;
    [SerializeField] private Toggle itemToggle;
    private ToggleGroup itemToggleGroup;

    public ItemProperty.ItemTypes itemType { get; private set; }
    public ItemProperty.Rarity rarity { get; private set; }

    public int quantityValue = 0;

    private void OnEnable()
    {
    }

    private void Start()
    {
        
    }

    public void ShopDisplayUI()
    {
        SetValues();
        SetQuantityText(itemProperty.quantity);
    }

    public void InventoryDisplayUI(int quantityValue)
    {
        SetValues();
        SetQuantityText(quantityValue);
    }


    public void SetValues()
    {
        itemToggleGroup = GetComponentInParent<ToggleGroup>();
        itemToggle.group = itemToggleGroup;
        itemImage.sprite = itemProperty.itemIcon;
       
        itemType = itemProperty.item;
        rarity = itemProperty.rarity;
    }
    

    public void SetQuantityText(int quantity)
    {
        quantityValue = quantity;
        this.quantity.text = quantity.ToString();
    }


    public void SetItemDetailPanel(bool isOn)
    {
        if (isOn)
            EventService.Instance.OnItemSelectedEventWithParams.InvokeEvent(isOn, this);
    }

    public void disableItem()
    {
        this.gameObject.SetActive(false) ;
    }

    public void EnabaleItem()
    {
        this.gameObject.SetActive(true);
    }
}
