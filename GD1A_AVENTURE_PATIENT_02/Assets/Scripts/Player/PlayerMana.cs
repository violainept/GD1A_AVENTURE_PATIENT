using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    // A RETIRER
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            UseMana(1f);
        }
    }

    public void UseMana(float amount)
    {
        if (stats.Mana >= amount)
        {
            stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);
        }
    }
}   
