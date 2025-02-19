using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{

    [SerializeField] private Toggle shopToggle;
    [SerializeField] private TextMeshProUGUI shoppOrInventoryText;
    [SerializeField] private CanvasGroup itemDeatilsPanelCanvasGroup;

    [Header("Item Properties")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemRarityText;
    [SerializeField] private TextMeshProUGUI itemWeightText;
    [SerializeField] private TextMeshProUGUI quantityAvailableText;
    [SerializeField] private TextMeshProUGUI itemBuyingPriceText;
    [SerializeField] private TextMeshProUGUI itemSellingPriceText;



    /*[SerializeField] private string itemName;
    [SerializeField] private ItemTypes item;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private string ItemDescription;
    [SerializeField] private int buyingPrice;
    [SerializeField] private int sellingPrice;
    [SerializeField] private float weight;
    [SerializeField] private Rarity rarity;
    [SerializeField] private int quantity;*/

    private UIController uiController;

    public void OnShopToggleChanged(bool isOn)
    {
        uiController.OnShopToggleChanged(isOn);
    }

    public void UpdateShopORInventoryText(bool isShopOpen)
    {
        shoppOrInventoryText.text = isShopOpen ? "Shop" : "Invenory";
        EventSystem.current.SetSelectedGameObject(null);

    }

    public void SetUIController(UIController uiController)
    {
        this.uiController = uiController;
    }

    public void SetItemDetailPanelView(bool isOn, ItemProperty itemProperty)
    {
        if (isOn == true)
        {
            itemDeatilsPanelCanvasGroup.alpha = 1;
            SetItemDetailPanelValues(itemProperty);
        }
    }

    public void SetItemDetailPanelValues(ItemProperty itemProperty)
    {
        this.itemName.text = itemProperty.name;
        this.itemImage.sprite = itemProperty.itemIcon;
        this.itemTypeText.text = FormatEnumText(itemProperty.item);
        this.itemRarityText.text = FormatEnumText(itemProperty.rarity);
        this.itemWeightText.text = itemProperty.weight.ToString();
        this.quantityAvailableText.text = itemProperty.quantity.ToString();
        this.itemDescriptionText.text = itemProperty.ItemDescription;
        this.itemBuyingPriceText.text = itemProperty.buyingPrice.ToString();
        this.itemSellingPriceText.text = itemProperty.buyingPrice.ToString();

    }

    private string FormatEnumText(Enum enumValue)
    {
        return System.Text.RegularExpressions.Regex.Replace(enumValue.ToString(), "(\\B[A-Z])", " $1");
    }

    public void print()
    {
        Debug.Log("Clicked");
    }
}
