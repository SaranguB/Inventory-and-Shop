using System;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemProperty : ScriptableObject
{

    public string itemName;
    public ItemTypes item;
    public Image itemIcon;
    public string ItemDescription;
    public int buyingPrice;
    public int sellingPrice;
    public int weight;
    public Rarity rarity;
    public int quantity;


    [Serializable]
    public enum ItemTypes
    {
        Materiels,
        Wepons,
        ConsumConsumables,
        Treasure
    }

    [Serializable]
    public enum Rarity
    {
        VeryCommon,
        Common,
        Rare,
        Epic,
        Legendary,
    }

}
