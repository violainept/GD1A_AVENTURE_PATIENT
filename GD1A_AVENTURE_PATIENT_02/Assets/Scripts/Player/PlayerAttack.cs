using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPosition;

    [Header("Melee Configurations")]
    [SerializeField] private ParticleSystem slashFX;
    [SerializeField] private float minDistanceMeleeAttack;

    public Weapon CurrentWeapon { get; set; }

    private PlayerMovements playerMovements;
    private PlayerMana playerMana;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;

    private Transform currentAttackPosition;
    private float currentAttackRotation;
    private void Awake()
    {
        playerMovements = GetComponent<PlayerMovements>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMana = GetComponent<PlayerMana>();
    }

    private void Start()
    {
        CurrentWeapon = initialWeapon; // when we equip a weapon, 'currentweapon' changes.
        Attack();
    }
    private void Update()
    {
        GetStarPosition();
    }
    private void OnEnable() // enemy selected
    {
        playerMovements.canMove = true;
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectionCallback;
        EnemyHealth.OnEnemyDeadEvent += NoEnemySelectionCallback;
    }

    private void OnDisable() // enemy not selected
    {
        playerMovements.canMove = false;
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectionCallback;
        EnemyHealth.OnEnemyDeadEvent -= NoEnemySelectionCallback;
    }

    private void Attack() // Attack
    {
        if (enemyTarget == null)
        {
            return;
        }
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

       attackCoroutine = StartCoroutine(IEAttack());
    }

    private IEnumerator IEAttack()
    {
        if (currentAttackPosition == null)
        {
            yield break;
        }

        if (CurrentWeapon.WeaponType == WeaponType.Magic) // if the player weapon is magic, do a magic attack
        {
            if (playerMana.CurrentMana < CurrentWeapon.RequiredMana)
            {
                yield break;
            }

            MagicAttack();
        }
        else // if the player weapon isn't magic, do a melee attack
        {
            MeleeAttack();
        }

        // timer animations
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttackAnimation(false);
    }

    private void MeleeAttack()
    {
        slashFX.transform.position = currentAttackPosition.position;
        slashFX.Play(); // particle effect

        float currentDistanceToEnemy = Vector3.Distance(enemyTarget.transform.position, transform.position);
        if (currentDistanceToEnemy <= minDistanceMeleeAttack)
        {
            enemyTarget.GetComponent<IDamageable>().TakeDamage(GetAttackDamage());
        }
    }

    private void MagicAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Projectile projectile = Instantiate(CurrentWeapon.ProjectilePrefab, currentAttackPosition.position, rotation);
        projectile.Direction = Vector3.up;
        projectile.Damage = GetAttackDamage();
        playerMana.UseMana(CurrentWeapon.RequiredMana);
    }

    private float GetAttackDamage()
    {
        float damage = playerStats.BaseDamage;
        damage += CurrentWeapon.Damage;
        float randomPercentage = Random.Range(0f, 100);

        if (randomPercentage <= playerStats.CriticalChance)
        {
            damage += damage * (playerStats.CriticalDamage / 100f);
        }

        return damage;
    }
    private void GetStarPosition() // get current position for each magic attack 
    {
        Vector2 moveDirection = playerMovements.moveDirection;
        switch (moveDirection.x)
        {
            case > 0f: // attack right
                currentAttackPosition = attackPosition[1];
                currentAttackRotation = -90f;
                break;

            case < 0f: // attack left
                currentAttackPosition = attackPosition[3];
                currentAttackRotation = -270f;
                break;
        }
        switch (moveDirection.y)
        {
            case > 0f: // attack up
                currentAttackPosition = attackPosition[0];
                currentAttackRotation = 0f;
                break;

            case < 0f: // attack down
                currentAttackPosition = attackPosition[2];
                currentAttackRotation = -180f;
                break;
        }
    }
    private void EnemySelectedCallback(EnemyBrain enemySelected) // when an enemy is selected
    {
        enemyTarget = enemySelected;
    }

    private void NoEnemySelectionCallback() // when no enemy is selected
    {
        enemyTarget = null;
    }
}
