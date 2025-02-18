using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController ShopController;
    private CanvasGroup shopCanvas;

    [SerializeField] private ItemDatabase itemDatabase;
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
        DisplayItems();
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

    private void DisplayItems()
    {

        
        foreach (ItemProperty item in itemDatabase.items)
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
