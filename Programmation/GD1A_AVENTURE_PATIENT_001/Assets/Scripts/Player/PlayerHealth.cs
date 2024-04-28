using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    private SpriteRenderer graphics;
    private PlayerAnimations playerAnimations;

    private float invincibilityTimeAfterHit = 3f;
    private float invincibilityFlashDelay = 0.2f;

    private bool isInvincible = false;



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
        if (!isInvincible)
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

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
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

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

}
