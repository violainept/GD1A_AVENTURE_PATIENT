using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    public float CurrentMana { get; private set; }



    public void UseMana(float amount)
    {
        if (stats.Mana >= amount)
        {
            stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);
            CurrentMana = stats.Mana;
        }
    }
    public void RecoverMana(float amount)
    {
        stats.Mana += amount;
        stats.Mana = Mathf.Min(stats.Mana, stats.MaxMana); // Keeps the minimal value
    }
    public bool CanRecoverMana()
    {
        return stats.Mana > 0 && stats.Mana < stats.MaxMana;
    }
    public void ResetMana()
    {
        CurrentMana = stats.MaxMana;
    }
}   
