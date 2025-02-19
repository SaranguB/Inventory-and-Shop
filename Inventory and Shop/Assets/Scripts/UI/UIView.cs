using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemProperty;

public class UIView : MonoBehaviour
{

    [SerializeField] private Toggle shopToggle;
    [SerializeField] private TextMeshProUGUI shoppOrInventoryText;

    [Header("Item properties")]
    [SerializeField] private Sprite itemImage;
    [SerializeField] private TextMeshProUGUI itemName;


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
}
