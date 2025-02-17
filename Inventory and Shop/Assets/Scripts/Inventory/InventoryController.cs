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

    public void EnableInventoryVisibility()
    {
        inventoryView.EnableInventoryVisibility();
    }

    public void DisableInventoryVisibility()
    {
        inventoryView.DisableInventoryVisibility();
    }


}
