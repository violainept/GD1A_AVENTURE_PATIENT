using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackRange : FSMDecision
{
    [Header("Configurations")]
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {
        throw new System.NotImplementedException();
    }

    private bool PlayerInAttackRange()
    {
        if (enemy.player == null)
        {
            return false;
        }
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerMask);
        if (playerCollider != null)

        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
