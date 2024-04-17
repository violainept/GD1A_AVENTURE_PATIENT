using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (stats.Health <= 0f)
        {
            PlayerDead();
        }
    }

    public void TakeDamage(float amount)
    {   
        if (stats.Health <= 0f)
        {
            return;
        }

        stats.Health -= amount;
        DamageManager.Instance.ShowDamageText(amount, transform);
        if (stats.Health <= 0f)
        {
            stats.Health = 0f;
            PlayerDead();
        }
    }

    public void RestoreHealth(float amount)
    {
        stats.Health += amount;
        if (stats.Health > stats.MaxHealth)
        {
            stats.Health = stats.MaxHealth;
        }
    }
    public bool CanRestoreHealth()
    {
        return stats.Health > 0 && stats.Health < stats.MaxHealth;
    }

    public void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }

}
