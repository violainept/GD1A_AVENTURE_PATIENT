using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//////////// Variables ////////////

    [Header("Configurations")]
    [SerializeField] private PlayerStats stats;

    // Allows to use stats
    public PlayerStats Stats => stats;

    private PlayerAnimations animations;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
    }
    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
    }
}
