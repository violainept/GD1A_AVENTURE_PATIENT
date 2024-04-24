using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPosition;

    [Header("Melee Configurations")]
    [SerializeField] private ParticleSystem slashFX;
    [SerializeField] private float minDistanceMeleeAttack;

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
        Attack();
    }

    private void Update()
    {
        GetStarPosition();
    }
    private void OnEnable() // Enemy selected
    {
        playerMovements.canMove = true;
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectionCallback;
        EnemyHealth.OnEnemyDeadEvent += NoEnemySelectionCallback;
    }

    private void OnDisable() // Enemy not selected
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
        if (currentAttackPosition != null) // rotation projectile
        {
            if (playerMana.CurrentMana < initialWeapon.RequiredMana)
            {
                yield break;
            }

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
            Projectile projectile = Instantiate(initialWeapon.ProjectilePrefab, currentAttackPosition.position, rotation);
            projectile.Direction = Vector3.up;
            projectile.Damage = initialWeapon.Damage;
            playerMana.UseMana(initialWeapon.RequiredMana);
        }

        // timer animations
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttackAnimation(false);
    }

    private void GetStarPosition() // get current position for each attack position
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
    private void EnemySelectedCallback(EnemyBrain enemySelected) // When Enemy is selected
    {
        enemyTarget = enemySelected;
    }

    private void NoEnemySelectionCallback() // When no Enemy is selected
    {
        enemyTarget = null;
    }
}
