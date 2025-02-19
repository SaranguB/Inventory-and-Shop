using System.Collections.Generic;
using UnityEngine;

public class ShopController
{

    private ShopView shopView;
    private ShopModel shopModel;

    public ShopController(ShopView shopView, ShopModel shopModel)
    {
        this.shopModel = shopModel;
        this.shopView = shopView;

        this.shopView.SetShopController(this);
        LoadShopItems();
    }

    public void EnableShopVisibility()
    {
        shopView.EnableShopVisibility();
    }
    public void DisableShopVisibility()
    {
        shopView.DisableShopVisibility();
    
    }

    public void LoadShopItems()
    {
        List<ItemProperty> items = shopModel.GetItemDatabase();
        shopView.DisplayItems(items);
    }
}
