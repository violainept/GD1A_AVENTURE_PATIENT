using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int horizontal = Animator.StringToHash("Horizontal");
    private readonly int vertical = Animator.StringToHash("Vertical");
    private readonly int lastHorizontal = Animator.StringToHash("LastHorizontal");
    private readonly int lastVertical = Animator.StringToHash("LastVertical");
    private readonly int speed = Animator.StringToHash("Speed");
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");
    private readonly int attackingMagic = Animator.StringToHash("AttackingMagic");
    private readonly int attackingMelee = Animator.StringToHash("AttackingMelee");


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleAnimation(Vector2 dir) // Player is motionless
    {
        animator.SetFloat(lastHorizontal, dir.x);
        animator.SetFloat(lastVertical, dir.y);
    }

    public void SetMovingAnimation(Vector2 dir) // Player is moving
    {
        animator.SetFloat(horizontal, dir.x);
        animator.SetFloat(vertical, dir.y);
        animator.SetFloat(speed, dir.sqrMagnitude);
    }

    public void SetMagicAttackAnimation(bool value) // Player is attacking with magic
    {
        animator.SetBool(attackingMagic, value);
    }

    public void SetMeleeAttackAnimation(bool value) // Player is attacking without magic
    {
        animator.SetBool(attackingMelee, value);
    }


    public void SetDeadAnimation() // Player is dead
    {
        animator.SetTrigger(dead);
    }

    // A REVOIR
    public void ResetPlayer()
    {
        SetMovingAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }
}
