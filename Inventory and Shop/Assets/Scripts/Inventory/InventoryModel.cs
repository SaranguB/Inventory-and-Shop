using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{

    private ItemDatabase itemDatabase;
    private List<ItemProperty> Items;
    public int inventoryValue = 5;
    public int numberOfResource { get; private set; }

    public InventoryModel(ItemDatabase itemDatabase)
    {
        this.itemDatabase = itemDatabase;
        Items = new List<ItemProperty>();
        numberOfResource = 5;

    }

    public List<ItemProperty> getItemDatabase()
    {
        if (Items.Count == 0)
        {
            Items.AddRange(itemDatabase.items);
        }

        return Items;
    }

}
