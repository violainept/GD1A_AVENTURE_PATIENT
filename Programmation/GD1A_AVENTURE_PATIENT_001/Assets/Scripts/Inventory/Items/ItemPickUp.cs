using UnityEngine;

// Not Completed
public class ItemPickUp : MonoBehaviour
{
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Inventory.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
