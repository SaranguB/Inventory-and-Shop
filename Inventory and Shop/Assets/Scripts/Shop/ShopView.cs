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

    bool isShopOn = true;

    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener(DisableShopVisibility);
        EventService.Instance.OnInventoryToggledOnEvent.AddListener(DisableBuyingSection);

        EventService.Instance.OnShopToggledOnEvent.AddListener(EnableShopVisibility);

        EventService.Instance.OnItemSelectedEvent.AddListener(EnableBuyingSection);
        EventService.Instance.OnItemSelectedEventWithParams.AddListener(SetBuyingSectionValues);

    }

    private void OnDisable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener(DisableShopVisibility);
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener(DisableBuyingSection);

        EventService.Instance.OnShopToggledOnEvent.RemoveListener(EnableShopVisibility);

        EventService.Instance.OnItemSelectedEvent.RemoveListener(EnableBuyingSection);
        EventService.Instance.OnItemSelectedEventWithParams.RemoveListener(SetBuyingSectionValues);


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
            ItemDisplay itemDisplay = newItem.GetComponent<ItemDisplay>();
            shopController.StoreItem(itemDisplay, shopFilterController);

            if (itemDisplay != null)
            {
                itemDisplay.itemProperty = item;
                itemDisplay.DisplayUI();
            }

        }
    }

    public void EnableBuyingSection()
    {
        if(isShopOn == true)
        {
            buySection.alpha = 1;
            buySection.interactable = true;
            buySection.blocksRaycasts = true;
        }
    } 

    public void SetBuyingSectionValues(bool isOn, ItemProperty itemProperty)
    {
        
        if(isOn)
        {
            quantityText.text = itemProperty.quantity.ToString();
            buyingPriceText.text = itemProperty.buyingPrice.ToString();
        }
    }
    public void DisableBuyingSection()
    {
       
        if(isShopOn == false)
        {
            buySection.alpha = 0;
            buySection.interactable = false;
            buySection.blocksRaycasts = false;
        }
    }
}
