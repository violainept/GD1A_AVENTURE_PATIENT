using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define how to go to a waypoint to another one
public class ActionPatrol : FSMAction
{
    [Header("Configurations")]
    [SerializeField] private float speed;

    private WayPoint waypoint;
    private int pointIndex;
    private Vector3 nextPosition;

    private void Awake()
    {
        waypoint = GetComponent<WayPoint>();
    }
    public override void Act()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, GetCurrentPosition()) <= 0.1f)
        {
            UpdateNextPosition();
        }
    }

    private void UpdateNextPosition()
    {
        pointIndex++;
        if (pointIndex > waypoint.Points.Length - 1) // Create a loop (example : Point 1 => 2 => 3 => 4 then 1 => 2 ...)
        {
            pointIndex = 0;
        }
    }

    private Vector3 GetCurrentPosition() // Update point index to go to the next point
    {
        return waypoint.GetPosition(pointIndex);
    }

}
