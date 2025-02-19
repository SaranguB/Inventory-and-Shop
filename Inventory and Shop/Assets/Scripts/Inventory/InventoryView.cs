using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryView : MonoBehaviour
{
    InventoryController inventoryController;
    private CanvasGroup inventoryCanvas;

    [SerializeField] private Transform parentPanel;
    [SerializeField] private GameObject itemPrefab;


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
        inventoryCanvas.blocksRaycasts = true;
        inventoryCanvas.interactable = true;
    }

    public void DisableInventoryVisibility()
    {
        inventoryCanvas.alpha = 0;
        inventoryCanvas.blocksRaycasts = false;
        inventoryCanvas.interactable = false;
    }

    public void GatheResource()
    {
        inventoryController.GatherResource();
    }

    public void DisplayItem(int index)
    {
        GameObject newItem = Instantiate(itemPrefab, parentPanel);
        ItemDisplay itemDisplay = newItem.GetComponent<ItemDisplay>();

        if (itemDisplay != null)
        {
            itemDisplay.itemProperty = inventoryController.GetItemDatabase()[index];
            itemDisplay.DisplayUI();
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
