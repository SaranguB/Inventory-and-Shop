using System;
using UnityEngine;

public class GameManager : GenericMonoSingelton<GameManager>
{
    public ShopController shopController { get; private set; }
    public InventoryController inventoryController { get; private set; }
    public UIService uiService { get; private set; }



    private ShopView shopView;
    private InventoryView inventoryView;

    
    private void Start()
    {
        CreateShop();
        CreateInventory();
        CreateUI();

    }

    private void CreateInventory()
    {
        InventoryModel inventoryModel = new InventoryModel();
        inventoryView = GameObject.FindFirstObjectByType<InventoryView>();
        inventoryController = new InventoryController(inventoryView, inventoryModel);
    }

    private void CreateUI()
    {
        //uiService.createUI();
    }

    private void CreateShop()
    {
        ShopModel shopModel = new ShopModel();
        shopView = GameObject.FindFirstObjectByType<ShopView>();
        shopController = new ShopController(shopView, shopModel);
    }

}
