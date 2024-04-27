using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define where to stop during a patrol
public class WayPoint : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 EntityPosition {  get; set; } // Saving CurrentPosition

    private bool gameStarted;

    private void Start()
    {
        EntityPosition = transform.position;
        gameStarted = true;
    }

    public Vector3 GetPosition(int pointIndex) // Get new position
    {
        return EntityPosition + points[pointIndex];
    }

    private void OnDrawGizmos()
    {
        if (gameStarted == false && transform.hasChanged)
        {
            EntityPosition = transform.position;
        }
    }
}
