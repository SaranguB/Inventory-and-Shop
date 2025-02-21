
using System;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


public class InventoryModel
{

    private ItemDatabase itemDatabase;
    private List<ItemProperty> Items;
    public int inventoryValue = 5;
    public int numberOfResource { get; private set; }

    public Dictionary<int, List<int>> itemQuantities;
    public int quantity;

    private Dictionary<int, ItemView> instantiatedItems = new Dictionary<int, ItemView>();

    public InventoryModel(ItemDatabase itemDatabase)
    {
        itemQuantities = new Dictionary<int, List<int>>();
        this.itemDatabase = itemDatabase;
        Items = new List<ItemProperty>();
        numberOfResource = 5;

        foreach (ItemProperty item in itemDatabase.items)
        {
            itemQuantities[item.itemId] = new List<int>();
        }

    }

    public List<ItemProperty> getItemDatabase()
    {
        if (Items.Count == 0)
        {
            Items.AddRange(itemDatabase.items);
        }

        return Items;
    }

    public void SetItemQuantities(int itemID, int newQuantity)
    {
        if (!itemQuantities.ContainsKey(itemID))
        {
            itemQuantities[itemID] = new List<int>();
        }
        itemQuantities[itemID].Add(newQuantity);

    }

    public List<int> GetQuantity(int itemID)
    {
        if (itemQuantities.ContainsKey(itemID))
        {
            return itemQuantities[itemID];

        }
        return new List<int>();
    }

    public void StoreInstantiatedItems(int itemID, ItemView itemView)
    {
        instantiatedItems[itemID] = itemView;

    }

    internal Dictionary<int, ItemView> GetInstatiatedItems()
    {
        return instantiatedItems;
    }


}
