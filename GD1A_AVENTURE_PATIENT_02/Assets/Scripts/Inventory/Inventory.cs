using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [Header("Configurations")]
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryItem[] inventoryItems;

    [Header("Testing")]
    public InventoryItem testItem;
    public int InventorySize => inventorySize;

    public void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            inventoryItems[0] = testItem.CopyItem();
            inventoryItems[0].Quantity = 10;
            InventoryUI.Instance.DrawItem(inventoryItems[0], 0);
        }
    }

}
