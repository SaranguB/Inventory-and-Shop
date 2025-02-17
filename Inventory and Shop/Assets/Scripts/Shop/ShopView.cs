using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{

    private ShopController ShopController;
    private CanvasGroup shopCanvas;

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
