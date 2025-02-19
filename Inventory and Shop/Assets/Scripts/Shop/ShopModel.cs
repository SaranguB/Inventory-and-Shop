using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
    private ItemDatabase itemDatabase;

    private List<ItemProperty> items;
    public ShopModel(ItemDatabase itemDatabase)
    {
        this.itemDatabase = itemDatabase;
        this.items = new List<ItemProperty>();
    }

    public List<ItemProperty> GetItemDatabase()
    {
        if(items.Count == 0)
        {
            items.AddRange(itemDatabase.items);
        }
        return items;
    }


}
