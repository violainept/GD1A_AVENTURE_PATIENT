using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Configurations")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenAttacks;

    private Animator animator;

    private EnemyBrain enemyBrain;
    private float timer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyBrain = GetComponent<EnemyBrain>();
    }
    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()

    {
        if (enemyBrain.player == null) // Player detected
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            animator.SetBool(("Attacking"), true);
            IDamageable player = enemyBrain.player.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeBetweenAttacks;
            animator.SetBool(("Attacking"), false);
        }
    }

}
