using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    public int previousSceneIndex;
    public PlayerStats Stats => stats; // Allows to use Player stats

    // A retirer
    [Header("Test")]
    public ItemFoodDrinks FoodDrinks;

    public PlayerMana PlayerMana { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }

    private PlayerAnimations animations;

    private void Awake()
    {
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
        animations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (FoodDrinks.UseItem())
            {
                Debug.Log("Using Food or Drinks.");
            }
        }
    }
    public void ResetPlayer() // Reset all stats
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
    }

    public void OnTriggerEnter2D(Collider2D collision) // Keeps the BuildIndex of the previous scene
    {
        if (collision.CompareTag("LoadIndex"))
        {
            previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
