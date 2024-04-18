using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private Weapon initalWeapon;
    [SerializeField] private Transform[] attackPosition;

    private PlayerMovements playerMovements;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;

    private void Awake()
    {
        playerMovements = GetComponent<PlayerMovements>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        Attack();
    }
    private void OnEnable() // Enemy selected
    {
        playerMovements.canMove = true;
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectionCallback;
    }

    private void OnDisable() // Enemy not selected
    {
        playerMovements.canMove = false;
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectionCallback;
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

    private IEnumerator IEAttack() // Timer animations
    {
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnimations.SetAttackAnimation(false);
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
