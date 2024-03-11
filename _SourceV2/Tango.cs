using UnityEngine;

public class Tango : MonoBehaviour
{
    // Variables
    public bool moveTowardsTarget = true; // Indicates whether the enemy should move towards a target
    public Transform target; // The target the enemy should move towards
    public float speed = 5f; // The speed at which the enemy moves

    // Health variables
    private int health = 5; // Initial health value
    private Renderer objectRenderer; // To change the object's color
    private bool bMoveToTarget = true; // Indicates whether the enemy should move towards a target

    // Unity Update method is called once per frame
    private void Update()
    {
        GetTargetLocation();

        // Move towards the target if it's not null and the option to move towards target is enabled
        if (target != null && bMoveToTarget)
        {
            MoveTowardsTarget();
        }
    }

    // Method to move towards the target
    private void MoveTowardsTarget()
    {
        if (target != null)
        {
            // Move towards the target's position at a constant speed
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    // Trigger method called when this object enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is a bullet
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            bMoveToTarget = false;
        }
    }

    private void GetTargetLocation()
    {
        // Get the target's location
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Method to handle taking damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Decrement the health when hit by a bullet
        Debug.Log("taking damage" + health + " remaining)");
        // Check the remaining health and destroy the object accordingly

        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the object if health reaches zero or below
        }
    }

    // Method to stop movement towards target
    public void StopMovingToTarget()
    {
        bMoveToTarget = false;
    }

    // Method to resume movement towards target
    public void ResumeMovingToTarget()
    {
        bMoveToTarget = true;
    }
}
