
using System;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


public class InventoryModel
{
    public ItemView currentItem;
    private ItemDatabase itemDatabase;
    private List<ItemProperty> Items;
    public Dictionary<ItemProperty.Rarity, bool> isRarityAvailable = new Dictionary<ItemProperty.Rarity, bool>();
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
            itemQuantities[item.itemID] = new List<int>();
        }


        isRarityAvailable[ItemProperty.Rarity.VeryCommon] = true;
        isRarityAvailable[ItemProperty.Rarity.Common] = false;
        isRarityAvailable[ItemProperty.Rarity.Legendary] = false;
        isRarityAvailable[ItemProperty.Rarity.Epic] = false;
        isRarityAvailable[ItemProperty.Rarity.Rare] = false;

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

    public void ResetQuantities(int itemID)
    {
        if(itemQuantities.ContainsKey(itemID))
        {
            itemQuantities[itemID].Clear();
        }
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

    public Dictionary<int, ItemView> GetInstatiatedItems()
    {
        return instantiatedItems;
    }

    public void SetRarityAvailable(ItemProperty.Rarity rarity, bool value)
    {
        if (isRarityAvailable.ContainsKey(rarity))
        {
            isRarityAvailable[rarity] = value;
        }
    }

    public bool IsRarityAvailable(ItemProperty.Rarity rairity)
    {
        return isRarityAvailable[rairity];
    }

    public void RemoveInstatiatedItem(int itemID)
    {
        if (instantiatedItems.ContainsKey(itemID))
        {

            instantiatedItems.Remove(itemID);
        }
        
    }
}
