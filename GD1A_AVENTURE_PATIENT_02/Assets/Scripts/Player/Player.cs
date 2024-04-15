using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    public int previousSceneIndex;
    public PlayerStats Stats => stats; // Allows to use stats
    
    private PlayerAnimations animations;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
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
