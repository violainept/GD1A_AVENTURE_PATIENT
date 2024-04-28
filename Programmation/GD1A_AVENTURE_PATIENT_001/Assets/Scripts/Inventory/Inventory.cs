using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [Header("Configurations")]
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryItem[] inventoryItems;
    public int InventorySize => inventorySize;

    public void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
    }

    public void AddItem(InventoryItem item, int quantity)
    {
        if (item == null || quantity <= 0)
        {
            return;
        }

        List<int> itemIndexes = CheckItemStock(item.ID);

        if (item.isStackable && itemIndexes.Count > 0) // add a/several unit of an 
        {
            foreach (var index in itemIndexes)
            {
                int maxStack = item.MaxStack;
                if (inventoryItems[index].Quantity < maxStack) // if the stack isn't full
                {
                    inventoryItems[index].Quantity += quantity;
                    if (inventoryItems[index].Quantity > maxStack) // if the stack is full
                    {
                        int dif = inventoryItems[index].Quantity - maxStack;
                        inventoryItems[index].Quantity = maxStack;
                        AddItem(item, dif);
                    }
                    InventoryUI.Instance.DrawItem(inventoryItems[index], index);
                }
            }
            int quantityToAdd = quantity > item.MaxStack ? item.MaxStack : quantity; // if it's true quantityToAdd = item.MaxStack, if it's false quantityToAdd = quantity
            AddItemFreeSlot(item, quantityToAdd);
            int remainingAmount = quantity - quantityToAdd;
            if (remainingAmount > 0)
            {
                AddItem(item, remainingAmount);
            }
        }
    }

    private void AddItemFreeSlot(InventoryItem item, int quantity)
    {
        for (int i = 0; i < inventorySize; i++) // loop to find an empty slot for our item
        {
            if (inventoryItems[i] != null)
            {
                continue; // go back to the loop and continue
            }
            inventoryItems[i] = item.CopyItem();
            inventoryItems[i].Quantity = quantity;
            InventoryUI.Instance.DrawItem(inventoryItems[i], i);
            return;
        }
    }

    private List<int> CheckItemStock(string itemID)
    {
        List<int> itemIndexes = new List<int>();

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                continue;
            }
            if (inventoryItems[i].ID == itemID)
            {
                itemIndexes.Add(i);
            }
        }
        return itemIndexes;
    }
}
