using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Food,
    Drink,
    Scroll,
    Ingredients,
    Treasure
}

[CreateAssetMenu(menuName = "Items/Item")]
public class InventoryItem : ScriptableObject
{
    [Header("Configurations")]
    public Sprite Icon;
    public string ID;
    public string Name;
    [TextArea] public string Description;

    [Header("Informations")]
    public ItemType itemType;
    public bool isConsumable;
    public bool isStackable;
    public int MaxStack;

    [HideInInspector] public int Quantity;
    public InventoryItem CopyItem()
    {
        InventoryItem instance = Instantiate(this);
        return instance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual void EquipItem()
    {

    }

    public virtual void RemoveItem()
    {

    }
}
