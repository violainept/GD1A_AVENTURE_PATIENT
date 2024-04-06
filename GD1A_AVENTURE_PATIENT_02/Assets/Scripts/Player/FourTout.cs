using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourTout : MonoBehaviour
{
    //////////// Variables ////////////

    [Header("Configurations")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Can't move diagonally //
        if (movement.x != 0)
        {
            movement.y = 0;
        }
        if (movement.y != 0)
        {
            movement.x = 0;
        }

        Animations();

    }

    private void FixedUpdate()
    {
        // Move player //
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //////////// Animations ////////////
    private void Animations()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetTrigger("Dead");

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }
}