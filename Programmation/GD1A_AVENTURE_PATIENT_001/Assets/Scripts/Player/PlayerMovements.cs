using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{

    [Header("Configurations")]
    [SerializeField] private float moveSpeed;

    public Vector2 moveDirection => movement;

    private PlayerActions actions;
    private Player player;
    private PlayerAnimations playerAnimations;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int previousSceneIndex;

    public bool canMove = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            Move();
        }
    }

    private void Move() // player movements
    {
        if (player.Stats.Health <= 0) return;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void ReadMovement() // All axis where Player can move (horizontal & vertical)
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // can'tt move diagonally
        if (movement.x != 0)
        {
            movement.y = 0;
        }
        if (movement.y != 0)
        {
            movement.x = 0;
        }

        if (movement != Vector2.zero) // player is motionless
        {
            playerAnimations.SetIdleAnimation(movement);
        }
        playerAnimations.SetMovingAnimation(movement); // player is moving

    }
    public void OnTriggerEnter2D(Collider2D collision) // keep previous scene index
    {
        if (collision.CompareTag("SceneChange"))
        {
            previousSceneIndex = SceneManager.GetActiveScene().buildIndex;

        }
    }
}