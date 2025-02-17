using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    InventoryController inventoryController;
    private CanvasGroup inventoryCanvas;

    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener
            (EnableInventoryVisibility);

        EventService.Instance.OnShopToggledOnEvent.AddListener(DisableInventoryVisibility);
        
    }
    public void SetInventoryController(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        inventoryCanvas = this.GetComponent<CanvasGroup>();
    }

    public void EnableInventoryVisibility()
    {
        inventoryCanvas.alpha = 1;
    }

    public void DisableInventoryVisibility()
    {
        inventoryCanvas.alpha = 0;
    }

}
