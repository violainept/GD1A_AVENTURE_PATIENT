using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealthDrink", menuName = "Items/Health Drink")]
public class ItemHealthDrink : InventoryItem
{
    [Header("Configurations")]
    public float HealthValue;
    public float ManaValue;

    public override bool UseItem()
    {
        if (GameManager.Instance.Player.PlayerHealth.CanRestoreHealth() && GameManager.Instance.Player.PlayerMana.CanRecoverMana() )
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
            GameManager.Instance.Player.PlayerMana.RecoverMana(ManaValue);
            return true;
        }
        return false;
    }
}

