using UnityEngine;

public class Box : MonoBehaviour
{
    private int health = 5; // Initial health value

    private Renderer objectRenderer; // To change the object's color

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>(); // Get the Renderer component attached to the object
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Decrement the health when the object is hit

        // Check the remaining health and change color or destroy the object accordingly
        if (health <= 2)
        {
            objectRenderer.material.color = Color.red; // Change color to red
        }

        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the object if health reaches zero or below
        }
    }
}
