using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static event Action OnEnemyDeadEvent;

    [Header("Configurations")]
    [SerializeField] private float health;

    public float CurrentHealth { get; private set; }

    private Animator animator;
    private EnemyBrain enemyBrain;
    private EnemySelector enemySelector;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
    }
    private void Start()
    {
        CurrentHealth = health;
    }
    public void TakeDamage(float amount) // When an Enemy takes damage
    {
        CurrentHealth -= amount;
        if (CurrentHealth >= 0f)
        {
            animator.SetTrigger("Dead");
            enemyBrain.enabled = false;
            enemySelector.NoSelectionCallBack();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            OnEnemyDeadEvent?.Invoke(); // if it's not null, invoke
        }
        else
        {
            DamageManager.Instance.ShowDamageText(amount, transform);
        }
    }
}
