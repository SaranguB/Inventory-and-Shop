using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterController : MonoBehaviour
{
    [SerializeField] private List<Toggle> filterToggle;
    private ItemProperty.ItemTypes currentFilterState;

    private Dictionary<Toggle, ItemProperty.ItemTypes> toggleFilterMap;

    private List<ItemDisplay> itemDisplay = new List<ItemDisplay>();
    bool showAll = true;

    private void Start()
    {
        
        currentFilterState = ItemProperty.ItemTypes.Materials;
       

        toggleFilterMap = new Dictionary<Toggle, ItemProperty.ItemTypes>
        {
            {filterToggle[0], ItemProperty.ItemTypes.Materials },
            {filterToggle[1], ItemProperty.ItemTypes.Weapons },
            {filterToggle[2], ItemProperty.ItemTypes.Consumables },
            {filterToggle[3], ItemProperty.ItemTypes.Treasure},
        };

        foreach (Toggle toggle in filterToggle)
        {
            toggle.onValueChanged.AddListener((isOn) => SetFilterState(toggle, isOn));
        }
    }

    void SetFilterState(Toggle changedToggle, bool isToggleOn)
    {

        if (isToggleOn == true && toggleFilterMap.ContainsKey(changedToggle))
        {
            currentFilterState = toggleFilterMap[changedToggle];
            ApplyFilter();
        }

    }

    public void ShowAll(bool isOn)
    {
        if (isOn)
        {
            showAll = true;
        }
        else
        {
            showAll = false;
            return;
        }

        foreach (ItemDisplay item in itemDisplay)
        {
            item.EnabaleItem();
        }

    }

    public void ApplyFilter()
    {
        if (showAll == true) return;

        foreach (ItemDisplay item in itemDisplay)
        {
            if (currentFilterState == item.itemType)
            {
                item.EnabaleItem();
            }
            else
            {
                item.disableItem();
            }
        }
    }

    public void AddItemDisplay(ItemDisplay newItemDisplay)
    {
        itemDisplay.Add(newItemDisplay);
    }
}
