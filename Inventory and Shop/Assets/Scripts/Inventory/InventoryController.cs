using System.Collections.Generic;
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
        for (int i = 0; i <= inventoryModel.numberOfResource; i++)
        {
            int index = GetRandomIndex(inventoryModel.inventoryValue);

            inventoryView.DisplayItem(index);
        }
    }

    private int GetRandomIndex(int inventoryValue)
    {
        int index = UnityEngine.Random.Range(0, GetItemDatabase().Count);
        return index;
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


}
