using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType // List
{
    Magic,
    Melee
}

[CreateAssetMenu(fileName = "Weapon_")]
public class Weapon : ScriptableObject
{
    [Header("Configurations")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    [Header ("Projectile")]
    public Projectile ProjectilePrefab;
    public float RequiredMana;
}
