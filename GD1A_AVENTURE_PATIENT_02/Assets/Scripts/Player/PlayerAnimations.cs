using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

//////////// Variables ////////////

    private readonly int horizontal = Animator.StringToHash("Horizontal");
    private readonly int vertical = Animator.StringToHash("Vertical");
    private readonly int lastHorizontal = Animator.StringToHash("LastHorizontal");
    private readonly int lastVertical = Animator.StringToHash("LastVertical");
    private readonly int speed = Animator.StringToHash("Speed");
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");

    private Animator animator;

//////////// Animations ////////////
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Dead 
    public void SetDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    // Movements 
    public void SetMovingAnimation(Vector2 dir)
    {
        animator.SetFloat(horizontal, dir.x);
        animator.SetFloat(vertical, dir.y);
        animator.SetFloat(speed, dir.sqrMagnitude);
    }

    // Idle 
    public void SetIdleAnimation(Vector2 dir)
    {
        animator.SetFloat(lastHorizontal, dir.x);
        animator.SetFloat(lastVertical, dir.y);
    }

    public void ResetPlayer()
    {
        SetMovingAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }
}
