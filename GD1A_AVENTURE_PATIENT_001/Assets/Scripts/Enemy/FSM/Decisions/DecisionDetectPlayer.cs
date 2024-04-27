using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSMDecision
{
    [Header("Configurations")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerMask;

    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return DetectPlayer();
    }
    private bool DetectPlayer()
    {
        Collider2D playerCollider =
            Physics2D.OverlapCircle(enemy.transform.position, range, playerMask);
        if (playerCollider != null)
        {
            enemy.player = playerCollider.transform;
            return true;
        }

        enemy.player = null;
        return false;
    }
    private void OnDrawGizmosSelected() // Visual range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
