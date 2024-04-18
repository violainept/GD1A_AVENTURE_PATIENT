using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthFood", menuName = "Items/Health Food")]
public class ItemHealthFood : InventoryItem
{
    [Header("Configurations")]
    public float HealthValue;

    public override bool UseItem() // When used, restore health with the chosen amount (if it's possible)
    {
        if (GameManager.Instance.Player.PlayerHealth.CanRestoreHealth())
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
            return true;
        }
        return false;
    }
}
