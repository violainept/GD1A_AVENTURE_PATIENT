using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header ("Configurations")]
    [SerializeField] private float speed;

    public Vector3 Direction { get; set; }

    private void Update()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
    }
}
