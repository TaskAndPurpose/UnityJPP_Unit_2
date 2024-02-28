using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Variables for health management.
    public float maxHealth = 1; // Maximum health of the object.
    public Image healthBar; // Reference to the health bar UI element.

    private float currentHealth; // Current health of the object.

    void Start()
    {
        currentHealth = maxHealth; // Set current health to maximum health when the game starts.
        UpdateHealthBar(); // Update the health bar UI to reflect the initial health.
    }

    // Method to reduce health when taking damage.
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Decrease health by the specified damage amount.

        // Make sure health doesn't go below 0.
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthBar(); // Update the health bar UI to reflect the new health value.

        // Check if the object's health has reached zero.
        if (currentHealth <= .2)
        {
            Destroy(transform.root.gameObject);
        }
    }

    // Method to update the health bar visuals based on current health.
    void UpdateHealthBar()
    {
        // Ensure the health bar reference is not null.
        if (healthBar != null)
        {
            // Calculate the fill amount of the health bar based on current health.
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    // Method to handle object destruction when health reaches zero.
    void Die()
    {
       
        Destroy(transform.root.gameObject);
    }

    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }
}