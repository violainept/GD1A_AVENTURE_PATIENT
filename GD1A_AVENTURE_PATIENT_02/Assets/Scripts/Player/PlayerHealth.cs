using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

//////////// Variables ////////////

    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    // A RETIRER
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1f);
        }
    }

//////////// Damage ////////////
    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            PlayerDead();
        }
    }

//////////// Death ////////////
    public void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }
}
