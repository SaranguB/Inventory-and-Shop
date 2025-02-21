using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class InventoryController
{
    private InventoryView inventoryView;
    private InventoryModel inventoryModel;

    public InventoryController(InventoryView inventoryView, InventoryModel inventoryModel)
    {
        this.inventoryView = inventoryView;

        this.inventoryView.SetInventoryController(this);
        this.inventoryModel = inventoryModel;
    }

    public void GatherResource()
    {
        for (int i = 0; i <inventoryModel.numberOfResource; i++)
        {
            int index = GetRandomIndex(inventoryModel.inventoryValue);

            inventoryView.DisplayItem(index);
        }
    }

    private int GetRandomIndex(int inventoryValue)
    {
        bool isItemForValue;
        int index;
        do
        {
            index = UnityEngine.Random.Range(0, GetItemDatabase().Count);
            isItemForValue = IsItemForValue(index);
        } while (!isItemForValue);

        return index;
    }

    private bool IsItemForValue(int index)
    {

        if (GetItemDatabase()[index].rarity == ItemProperty.Rarity.Common)
        {
            return true;
        }
        return false;

    }
    public void EnableInventoryVisibility()
    {
        inventoryView.EnableInventoryVisibility();
    }

    public void DisableInventoryVisibility()
    {
        inventoryView.DisableInventoryVisibility();
    }

    public List<ItemProperty> GetItemDatabase()
    {
        return inventoryModel.getItemDatabase();
    }

    public void ApplyFilter(FilterController inventoryFilterController)
    {
        inventoryFilterController.ApplyFilter();
    }

    public void StoreItem(ItemView itemDisplay, FilterController inventoryFilterController)
    {

        inventoryFilterController.AddItemDisplay(itemDisplay);
    }

    public int GenerateRandomQuantity()
    {
        int quantity = UnityEngine.Random.Range(1, 5);
        return quantity;
    }

    public void SetQuantitity(int itemId, int quantity)
    {
        //Debug.Log(quantity);
        inventoryModel.SetItemQuantities(itemId, quantity);
    }

    public int GetSumQuantity(int itemID)
    {
        return inventoryModel.GetQuantity(itemID).Sum();
    }

    public bool IsItemAlreadyInstantiated(int itemID)
    {

        return inventoryModel.GetInstatiatedItems().ContainsKey(itemID);

    }

    public ItemView GetInstantiatedItem(int itemID)
    {
        return inventoryModel.GetInstatiatedItems().TryGetValue(itemID, out ItemView itemView) ? itemView : null;
    }

    public void StoreInstantiatedItem(int itemID, ItemView itemView)
    {

        inventoryModel.StoreInstantiatedItems(itemID, itemView);
    }


}
