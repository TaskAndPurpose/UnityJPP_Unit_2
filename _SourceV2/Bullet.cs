using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb; // Removed the underscore to match common public variable naming conventions
    public float bulletSpeed = 250f; // Units per second
    public int timeTillDestroy = 10;
    
    private void Start()
    {
        // Apply initial velocity
        rb.velocity = transform.forward * bulletSpeed; // Removed Time.deltaTime

        // Schedule self-destruction
        Destroy(gameObject, timeTillDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hits a target tagged as "Tango"
        if (other.CompareTag("Tango"))
        {
            // Optionally, log hit for debugging
            Debug.Log("Hit Tango");
            other.GetComponent<Tango>().TakeDamage(1); // Removed the underscore to match common method naming conventions
        }


        if (other.CompareTag("Box"))
        {
            Debug.Log("Hit Box");
            other.GetComponent<Box>().TakeDamage(1);
        }
    
    }
}
