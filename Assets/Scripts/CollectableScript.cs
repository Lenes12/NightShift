using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Add your collection logic here (e.g., increase score, update UI)
        Debug.Log("Object collected!");

        // Destroy the collectible object after it's collected
        Destroy(gameObject);
    }
}
