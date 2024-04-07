using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayersStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Configurations")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Experience")]
    public float CurrentExp;
    public float NextLevelExp;
    public float InitialNextLevelEx;
    [Range(1f, 100f)] public float ExpMultiplier;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Level = 1;
        CurrentExp = 0;
        NextLevelExp = InitialNextLevelEx;
    }
}
