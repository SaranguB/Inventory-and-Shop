using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController shopController;
    private CanvasGroup shopCanvas;
    [SerializeField] private FilterController shopFilterController;

    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Transform parentPanel;

    [Header("Buy Section")]
    [SerializeField] private CanvasGroup buySection;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private TextMeshProUGUI buyingPriceText;

    public bool isShopOn = true;

    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener(DisableShopVisibility);
        EventService.Instance.OnInventoryToggledOnEvent.AddListener(DisableBuyingSection);

        EventService.Instance.OnShopToggledOnEvent.AddListener(EnableShopVisibility);

        EventService.Instance.OnItemSelectedEvent.AddListener(EnableBuyingSection);
        EventService.Instance.OnItemSelectedEventWithParams.AddListener(SetCurrentSelected);

    }

    private void OnDisable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener(DisableShopVisibility);
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener(DisableBuyingSection);

        EventService.Instance.OnShopToggledOnEvent.RemoveListener(EnableShopVisibility);

        EventService.Instance.OnItemSelectedEvent.RemoveListener(EnableBuyingSection);
        EventService.Instance.OnItemSelectedEventWithParams.RemoveListener(SetCurrentSelected);


    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
        shopCanvas = this.GetComponent<CanvasGroup>();

    }

    public void EnableShopVisibility()
    {
        isShopOn = true;
        shopCanvas.alpha = 1;
        shopCanvas.interactable = true;
        shopCanvas.blocksRaycasts = true;
    }

    public void DisableShopVisibility()
    {
        isShopOn = false;
        shopCanvas.alpha = 0;
        shopCanvas.interactable = false;
        shopCanvas.blocksRaycasts = false;
    }

    public void DisplayItems(List<ItemProperty> items)
    {

        foreach (ItemProperty item in items)
        {

            GameObject newItem = Instantiate(itemPrefab, parentPanel);
            ItemView itemDisplay = newItem.GetComponent<ItemView>();
            shopController.StoreItem(itemDisplay, shopFilterController);

            if (itemDisplay != null)
            {
                itemDisplay.itemProperty = item;
                shopController.SetItemQuantities(itemDisplay.itemProperty.itemID, itemDisplay.itemProperty.quantity);
                itemDisplay.ShopDisplayUI();
            }

        }
    }

    public void EnableBuyingSection()
    {
        if (isShopOn == true)
        {
            buySection.alpha = 1;
            buySection.interactable = true;
            buySection.blocksRaycasts = true;
        }
    }

    public void SetCurrentSelected(bool isOn, ItemView itemView)
    {
        shopController.SetCurrentSelectedItem(itemView);
        SetBuySectionValues(isOn);

    }

    private void SetBuySectionValues(bool isOn)
    {
        if (isOn)
        {

            quantityText.text = 0.ToString();
            buyingPriceText.text = 0.ToString();
        }
    }

    public void AddBuySectionValues()
    {
        int itemID = shopController.GetCurrentItem().itemProperty.itemID;
        int AvailableQuantity = shopController.GetItemQuantity(itemID);
        int quantity = int.Parse(quantityText.text);
        int buyingPrice = int.Parse(buyingPriceText.text);

        if (quantity < AvailableQuantity)
        {
            quantityText.text = (quantity + 1).ToString();
            buyingPriceText.text = (buyingPrice + shopController.GetCurrentItem().itemProperty.buyingPrice).ToString();
        }
    }

    public void ReduceBuySectionValues()
    {
        int itemID = shopController.GetCurrentItem().itemProperty.itemID;
        int AvailableQuantity = shopController.GetItemQuantity(itemID);
        int quantity = int.Parse(quantityText.text);
        int buyingPrice = int.Parse(buyingPriceText.text);

        if (quantity > 0)
        {
            quantityText.text = (quantity - 1).ToString();
            buyingPriceText.text = (buyingPrice - shopController.GetCurrentItem().itemProperty.buyingPrice).ToString();
        }
    }



    public void DisableBuyingSection()
    {

        if (isShopOn == false)
        {
            buySection.alpha = 0;
            buySection.interactable = false;
            buySection.blocksRaycasts = false;
        }
    }

    public void Buy()
    {
        int amount = int.Parse(buyingPriceText.text);
        int quantity = int.Parse(quantityText.text);

        int itemID = shopController.GetCurrentItem().itemProperty.itemID;

        if (shopController.GetPlayerCoin() >= amount && amount > 0)
        {
            SetBuySectionValues(true);
            
            amount = GameManager.Instance.playerController.GetPlayerCoinCount() - amount;
            
            GameManager.Instance.playerController.SetPlayerCoin(amount);
            GameManager.Instance.inventoryController.DisplayBroughtItems(shopController.GetCurrentItem(), quantity);
        }


    }

}
