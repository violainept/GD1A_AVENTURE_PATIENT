using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWander : FSMAction
{
    [Header("Configurations")]
    [SerializeField] private float speed;
    [SerializeField] private float wanderTime; // Time they change they position
    [SerializeField] private Vector2 moveRange; //Area where the enemy can go

    private Vector3 movePosition;
    private float timer; //Controls wanderTime

    private void Start()
    {
        GetNewDestination();
    }

    public override void Act()
    {
        timer -= Time.deltaTime;
        Vector3 moveDirection = (movePosition - transform.position).normalized;
        Vector3 movement = moveDirection * (speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePosition) >= 0.5f) // Avoid collision mistakes
        {
            transform.Translate(movement);
        }
        if (timer < 0f)
        {
            GetNewDestination();
            timer = wanderTime;
        }
    }

    private void GetNewDestination() // Get a random position in a define area 
    {
        float randomX = Random.Range(-moveRange.x, moveRange.x);
        float randomY = Random.Range(-moveRange.y, moveRange.y);
        movePosition = transform.position + new Vector3(randomX, randomY);
    }

    private void OnDrawGizmos()
    {
        if (moveRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f); //Shows moveRange
            Gizmos.DrawLine(transform.position, movePosition); //To knows where Enemy is moving
        }
    }
}
