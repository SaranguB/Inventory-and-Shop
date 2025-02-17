using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController ShopController;
    private CanvasGroup shopCanvas;

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
    } 
    
    public void DisableShopVisibility()
    {
        shopCanvas.alpha = 0;
    }
}
