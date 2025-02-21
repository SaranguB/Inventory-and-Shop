using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
    private ItemDatabase itemDatabase;
    public ItemView currentItem;

    private List<ItemProperty> items;
    public Dictionary<int, int> itemQuantities = new Dictionary<int, int>();

    public ShopModel(ItemDatabase itemDatabase)
    {
        this.itemDatabase = itemDatabase;
        this.items = new List<ItemProperty>();

        foreach(ItemProperty item in itemDatabase.items)
        {
            itemQuantities[item.itemID] = 0;
        }


    }

    public List<ItemProperty> GetItemDatabase()
    {
        if(items.Count == 0)
        {
            items.AddRange(itemDatabase.items);
        }
        return items;
    }

    public void SetItemQuantities(int itemID, int quantity)
    {
        if(itemQuantities.ContainsKey(itemID))
        {
            itemQuantities[itemID] = quantity;
            //Debug.Log(itemQuantities[itemID]);
        }
    }

    public int GetQuantity(int itemID)
    {
        if(itemQuantities.ContainsKey(itemID))
        {
            return itemQuantities[itemID];
        }
        return 0;
    }


}
