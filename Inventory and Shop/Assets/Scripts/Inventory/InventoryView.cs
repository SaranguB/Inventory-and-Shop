using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public bool isInventoryOn = false;


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
        EventService.Instance.onItemSold.RemoveListener(inventoryController.SetPanelViews);

    }
    public void SetInventoryController(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        inventoryCanvas = this.GetComponent<CanvasGroup>();
        EventService.Instance.onItemSold.AddListener(inventoryController.SetPanelViews);
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
        if (inventoryController.GetPlayerBagWeight() < inventoryController.GetPlayerBagCapacity())
        {
            inventoryController.GatherResource();
            inventoryController.SetBagWeight(inventoryController.GetTotalWeight());
        }
    }

    public void DisplayGatheredItem(int index)
    {
        int itemID = inventoryController.GetItemDatabase()[index].itemID;
        int newQuantity = inventoryController.GenerateRandomQuantity();
        ItemProperty itemProperty = inventoryController.GetItemDatabase()[index];

        InstantiateItems(itemID, newQuantity, itemProperty);

    }

    public void DisplayBroughtItem(ItemView itemView, int newQuantity)
    {
        int itemID = itemView.itemProperty.itemID;

        if (itemView != null)
        {
            InstantiateItems(itemID, newQuantity, itemView.itemProperty);
        }
    }

    private void InstantiateItems(int itemID, int newQuantity, ItemProperty itemProperty)
    {
        if (inventoryController.IsItemAlreadyInstantiated(itemID))
        {
            inventoryController.SetQuantity(itemID, newQuantity);

            ItemView existingItem = inventoryController.GetInstantiatedItem(itemID);
            inventoryController.SetItemWeight(itemID, existingItem.itemProperty.weight);


            if (existingItem != null)
            {
                int totalQuantity = inventoryController.GetItemQuantity(existingItem.itemProperty.itemID);
                existingItem.InventoryDisplayUI(totalQuantity);
            }
        }
        else
        {

            GameObject newItem = Instantiate(itemPrefab, parentPanel);
            ItemView itemView = newItem.GetComponent<ItemView>();

            if (itemView != null)
            {
                itemView.itemProperty = itemProperty;
                inventoryController.StoreItem(itemView, inventoryFilterController);

                inventoryController.SetQuantity(itemView.itemProperty.itemID, newQuantity);
                inventoryController.SetItemWeight(itemID, itemView.itemProperty.weight);

                inventoryController.StoreInstantiatedItem(itemView.itemProperty.itemID, itemView);

                itemView.InventoryDisplayUI(inventoryController.GetItemQuantity(itemView.itemProperty.itemID));
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
        SetSellSectionValues(isOn);
    }

    private void SetSellSectionValues(bool isOn)
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
            sellingPriceText.text = (sellingPrice + inventoryController.GetCurrentItem().itemProperty.sellingPrice).ToString();

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
            sellingPriceText.text = (sellingPrice - inventoryController.GetCurrentItem().itemProperty.sellingPrice).ToString();

        }
    }

    public void Sell()
    {
        int amount = int.Parse(sellingPriceText.text);
        int quantity = int.Parse(quantityText.text);

        int itemID = inventoryController.GetCurrentItem().itemProperty.itemID;

        if (amount > 0 && quantity >0)
        {
            SetSellSectionValues(true);
            inventoryController.RemoveWeight(itemID, quantity);

            quantity = inventoryController.GetItemQuantity(itemID) - quantity;

            inventoryController.ResetQuantities(itemID);
            inventoryController.SetQuantity(itemID, quantity);
            inventoryController.GetCurrentItem().SetQuantityText(quantity);

            EventService.Instance.onItemSold.InvokeEvent();
            EventService.Instance.onItemSoldWithIntParams.InvokeEvent(amount);
            EventService.Instance.onItemSoldWithFloatParams.InvokeEvent(inventoryController.GetTotalWeight());

            if (quantity <= 0)
            {
                RemoveItem(itemID);
            }

        }


      
    }

    private void RemoveItem(int itemID)
    {
        ItemView itemToRemove = inventoryController.GetCurrentItem();

        if (itemToRemove != null)
        {
            inventoryController.RemoveItem(itemID);
            Destroy(itemToRemove.gameObject);
        }


    }
}
