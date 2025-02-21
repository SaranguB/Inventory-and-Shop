using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryView : MonoBehaviour
{
    InventoryController inventoryController;
    private CanvasGroup inventoryCanvas;

    [SerializeField] private Transform parentPanel;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private FilterController inventoryFilterController;
    [SerializeField] private CanvasGroup sellingSection;
    bool isInventoryOn = false;


    private void OnEnable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.AddListener
            (EnableInventoryVisibility);

        EventService.Instance.OnShopToggledOnEvent.AddListener(DisableInventoryVisibility);
        EventService.Instance.OnShopToggledOnEvent.AddListener(DisableSellingSection);

        EventService.Instance.OnItemSelectedEvent.AddListener(EnableSellingSection);

    }

    private void OnDisable()
    {
        EventService.Instance.OnInventoryToggledOnEvent.RemoveListener
           (EnableInventoryVisibility);

        EventService.Instance.OnShopToggledOnEvent.RemoveListener(DisableInventoryVisibility);
        EventService.Instance.OnShopToggledOnEvent.RemoveListener(DisableSellingSection);

        EventService.Instance.OnItemSelectedEvent.RemoveListener(EnableSellingSection);
    }
    public void SetInventoryController(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        inventoryCanvas = this.GetComponent<CanvasGroup>();
    }

    public void EnableInventoryVisibility()
    {
        isInventoryOn = true;
        inventoryCanvas.alpha = 1;
        inventoryCanvas.blocksRaycasts = true;
        inventoryCanvas.interactable = true;
    }

    public void DisableInventoryVisibility()
    {
        isInventoryOn = false;
        inventoryCanvas.alpha = 0;
        inventoryCanvas.blocksRaycasts = false;
        inventoryCanvas.interactable = false;
    }

    public void GatherResource()
    {
        inventoryController.GatherResource();
    }

    public void DisplayItem(int index)
    {
        GameObject newItem = Instantiate(itemPrefab, parentPanel);
        ItemDisplay itemDisplay = newItem.GetComponent<ItemDisplay>();
        inventoryController.StoreItem(itemDisplay, inventoryFilterController);

        if (itemDisplay != null)
        {
            itemDisplay.itemProperty = inventoryController.GetItemDatabase()[index];
            itemDisplay.DisplayUI();
        }
        inventoryController.ApplyFilter(inventoryFilterController);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void EnableSellingSection()
    {
        if (isInventoryOn == true)
        {
            sellingSection.alpha = 1;
            sellingSection.interactable = true;
            sellingSection.blocksRaycasts = true;
        }
    }
    public void DisableSellingSection()
    {
        if (isInventoryOn == false)
        {
            sellingSection.alpha = 0;
            sellingSection.interactable = false;
            sellingSection.blocksRaycasts = false;
        }
    }
}
