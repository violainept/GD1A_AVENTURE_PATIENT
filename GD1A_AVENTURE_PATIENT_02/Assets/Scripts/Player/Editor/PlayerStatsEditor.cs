using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStats))]

// Allow to modify PlayerStats : make a button appear, using the desired script
public class PlayerStatsEditor : Editor
{
    private PlayerStats StatsTarget => target as PlayerStats;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset Player"))
        {
            StatsTarget.ResetPlayer();
        }
    }
}
