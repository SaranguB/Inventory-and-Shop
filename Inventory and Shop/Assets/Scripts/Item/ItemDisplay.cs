using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemProperty itemProperty;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private Toggle itemToggle;
    private ToggleGroup itemToggleGroup;
    [SerializeField] private CanvasGroup itemCanvasGroup;

    public ItemProperty.ItemTypes itemType { get; private set; }


    private void Start()
    {
        itemCanvasGroup = GetComponent<CanvasGroup>();
    }
    public void DisplayUI()
    {
        itemToggleGroup = GetComponentInParent<ToggleGroup>();
        itemToggle.group = itemToggleGroup;

        itemImage.sprite = itemProperty.itemIcon;
        quantity.text = itemProperty.quantity.ToString();

        itemType = itemProperty.item;
    }

    public void SetItemDetailPanel(bool isOn)
    {
        if (isOn)
            GameManager.Instance.uiController.SetItemDetailsPanel(isOn, itemProperty);
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
