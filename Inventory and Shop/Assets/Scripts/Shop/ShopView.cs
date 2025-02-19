using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController ShopController;
    private CanvasGroup shopCanvas;

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
        this.ShopController = shopController;
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


            if (itemDisplay != null)
            {
                itemDisplay.itemProperty = item;
                itemDisplay.DisplayUI();
            }

        }
    }


}
