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
}
