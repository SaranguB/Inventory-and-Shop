using System;
using UnityEngine;

public class ShopController
{

    private ShopView shopView;
    private ShopModel shopModel;

    public ShopController(ShopView shopView, ShopModel shopModel)
    {
        this.shopView = shopView;

        this.shopView.SetShopController(this);
        this.shopModel = shopModel;
    }

    public void EnableShopVisibility()
    {
        shopView.EnableShopVisibility();
    }
    public void DisableShopVisibility()
    {
        shopView.DisableShopVisibility();
    }
}
