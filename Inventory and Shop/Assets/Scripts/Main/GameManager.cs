using System;
using UnityEditor;
using UnityEngine;

public class GameManager : GenericMonoSingelton<GameManager>
{
    public ShopController shopController { get; private set; }
    public InventoryController inventoryController { get; private set; }
    public UIController uiController { get; private set; }

    private UIView uiView;
    private ShopView shopView;
    private InventoryView inventoryView;

    [SerializeField] private ItemDatabase itemDatabase;
    
    private void Start()
    {
        CreateUI();
        CreateShop();
        CreateInventory();

    }

  
    private void CreateInventory()
    {
        InventoryModel inventoryModel = new InventoryModel();
        inventoryView = GameObject.FindFirstObjectByType<InventoryView>();
        inventoryController = new InventoryController(inventoryView, inventoryModel);
    }

    private void CreateUI()
    {
        uiView = GameObject.FindFirstObjectByType<UIView>();
        uiController = new UIController(uiView);
        
    }

    private void CreateShop()
    {
        ShopModel shopModel = new ShopModel(itemDatabase);
        shopView = GameObject.FindFirstObjectByType<ShopView>();
        shopController = new ShopController(shopView, shopModel);
    }

}
