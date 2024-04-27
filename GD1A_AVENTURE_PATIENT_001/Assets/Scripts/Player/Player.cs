using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    public int previousSceneIndex;
    public PlayerStats Stats => stats;
    public PlayerMana PlayerMana { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }

    private PlayerAnimations animations;

    private void Awake()
    {
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
        animations = GetComponent<PlayerAnimations>();
    }

    public void ResetPlayer() // Reset all Player stats (HP, PM)
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
        PlayerMana.ResetMana();
    }

    public void OnTriggerEnter2D(Collider2D collision) // Keep the BuildIndex of the previous scene
    {
        if (collision.CompareTag("LoadIndex"))
        {
            previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
