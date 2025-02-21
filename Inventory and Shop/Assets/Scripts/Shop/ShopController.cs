using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopController
{

    private ShopView shopView;
    private ShopModel shopModel;
    FilterController filter;
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

    public void StoreItem(ItemView itemDisplay, FilterController shopFilterController)
    {
        /*if(shopFilterController!=null)
        {
            Debug.Log("null");
        }*/
        shopFilterController.AddItemDisplay(itemDisplay);
    }
}
