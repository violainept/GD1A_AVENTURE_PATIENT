using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //////////// Variables ////////////

    [Header("Configurations")]
    [SerializeField] private float moveSpeed;

    private PlayerAnimations playerAnimations;
    private Rigidbody2D rb;
    private Vector2 movement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        // Move player //
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void ReadMovement()
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

        if (movement != Vector2.zero)
        {
            playerAnimations.SetIdleAnimation(movement);
        }
            playerAnimations.SetMovingAnimation(movement);

    }
}