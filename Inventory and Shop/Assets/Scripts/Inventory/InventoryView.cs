using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class InventoryView : MonoBehaviour
{
    InventoryController inventoryController;
    private CanvasGroup inventoryCanvas;

    [SerializeField] private Transform parentPanel;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private FilterController inventoryFilterController;

    [Header("Sell Section")]
    [SerializeField] private CanvasGroup sellSection;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private TextMeshProUGUI sellingPriceText;
    bool isInventoryOn = false;


    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener
            (EnableInventoryVisibility);

        EventService.Instance.OnShopToggledOnEvent.AddListener(DisableInventoryVisibility);
        EventService.Instance.OnShopToggledOnEvent.AddListener(DisableSellSection);

        EventService.Instance.OnItemSelectedEvent.AddListener(EnableSellSection);
        EventService.Instance.OnItemSelectedEventWithParams.AddListener(SetSelecteddItem);

    }

    private void OnDisable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener
           (EnableInventoryVisibility);

        EventService.Instance.OnShopToggledOnEvent.RemoveListener(DisableInventoryVisibility);
        EventService.Instance.OnShopToggledOnEvent.RemoveListener(DisableSellSection);

        EventService.Instance.OnItemSelectedEvent.RemoveListener(EnableSellSection);
    }
    public void SetInventoryController(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        inventoryCanvas = this.GetComponent<CanvasGroup>();
    }


    public void EnableInventoryVisibility()
    {
        isInventoryOn = true;
        inventoryCanvas.alpha = 1;
        inventoryCanvas.blocksRaycasts = true;
        inventoryCanvas.interactable = true;
    }

    public void DisableInventoryVisibility()
    {
        isInventoryOn = false;
        inventoryCanvas.alpha = 0;
        inventoryCanvas.blocksRaycasts = false;
        inventoryCanvas.interactable = false;
    }

    public void GatherResource()
    {
        inventoryController.GatherResource();
    }

    public void DisplayItem(int index)
    {
        int itemID = inventoryController.GetItemDatabase()[index].itemID;
        int newQuantity = inventoryController.GenerateRandomQuantity();

        if (inventoryController.IsItemAlreadyInstantiated(itemID))
        {
            inventoryController.SetQuantitity(itemID, newQuantity);

            ItemView existingItem = inventoryController.GetInstantiatedItem(itemID);

            if (existingItem != null)
            {
                int totalQuantity = inventoryController.GetItemQuantity(existingItem.itemProperty.itemID);
                existingItem.InventoryDisplayUI(totalQuantity);
            }
        }
        else
        {

            GameObject newItem = Instantiate(itemPrefab, parentPanel);
            ItemView itemDisplay = newItem.GetComponent<ItemView>();

            if (itemDisplay != null)
            {
                itemDisplay.itemProperty = inventoryController.GetItemDatabase()[index];
                inventoryController.StoreItem(itemDisplay, inventoryFilterController);

                inventoryController.SetQuantitity(itemDisplay.itemProperty.itemID, newQuantity);

                inventoryController.StoreInstantiatedItem(itemDisplay.itemProperty.itemID, itemDisplay);

                itemDisplay.InventoryDisplayUI(inventoryController.GetItemQuantity(itemDisplay.itemProperty.itemID));
            }
        }

        inventoryController.ApplyFilter(inventoryFilterController);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void EnableSellSection()
    {
        if (isInventoryOn == true)
        {
            sellSection.alpha = 1;
            sellSection.interactable = true;
            sellSection.blocksRaycasts = true;
        }
    }
    public void DisableSellSection()
    {
        if (isInventoryOn == false)
        {
            sellSection.alpha = 0;
            sellSection.interactable = false;
            sellSection.blocksRaycasts = false;
        }
    }

    public void SetSelecteddItem(bool isOn, ItemView ItemView)
    {
        inventoryController.SetCurrentItem(ItemView);
        SetSellSectionValues(isOn, ItemView);
    }

    private void SetSellSectionValues(bool isOn, ItemView itemDisplay)
    {

        if (isOn)
        {
            quantityText.text = 0.ToString();
            sellingPriceText.text = 0.ToString();
        }
    }

    public void AddQuantity()
    {
        int itemID = inventoryController.GetCurrentItem().itemProperty.itemID;
        int AvailableQuantity = inventoryController.GetItemQuantity(itemID);
        int quantity = int.Parse(quantityText.text);
        int sellingPrice = int.Parse(sellingPriceText.text);

        if (quantity < AvailableQuantity)
        { 
            quantityText.text = (quantity + 1).ToString();
            sellingPriceText.text = (sellingPrice + inventoryController.GetCurrentItem().itemProperty.buyingPrice).ToString();

        }
    }

    public void ReduceQuantity()
    {
        int itemID = inventoryController.GetCurrentItem().itemProperty.itemID;
        int AvailableQuantity = inventoryController.GetItemQuantity(itemID);
        int quantity = int.Parse(quantityText.text);
        int sellingPrice = int.Parse(sellingPriceText.text);

        if (quantity > 0)
        {
            quantityText.text = (quantity - 1).ToString();
            sellingPriceText.text = (sellingPrice - inventoryController.GetCurrentItem().itemProperty.buyingPrice).ToString();

        }
    }

}
