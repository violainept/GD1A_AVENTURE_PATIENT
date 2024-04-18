using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthFood", menuName = "Items/Health Food")]
public class ItemHealthFood : InventoryItem
{
    [Header("Configurations")]
    public float HealthValue;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerHealth.CanRestoreHealth()) // If Player is able to use the Item
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
            return true;
        }
        return false;
    }
}
