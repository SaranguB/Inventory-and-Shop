using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController shopController;
    private CanvasGroup shopCanvas;
    [SerializeField] private FilterController shopFilterController;

    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Transform parentPanel;

    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener
              (DisableShopVisibility);

        EventService.Instance.OnShopToggledOnEvent.AddListener(EnableShopVisibility);
    }

    public void SetShopController(ShopController shopController)
    {
        this.shopController = shopController;
        shopCanvas = this.GetComponent<CanvasGroup>();

    }

    public void EnableShopVisibility()
    {
        shopCanvas.alpha = 1;
        shopCanvas.interactable = true;
        shopCanvas.blocksRaycasts = true;
    }

    public void DisableShopVisibility()
    {
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


}
