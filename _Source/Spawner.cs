using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnTime = 3f; // The amount of time between each spawn
   public Transform spawnPoint; // An array of the spawn points this enemy can spawn from
   

    // Method to spawn an enemy
    private void Spawn()
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
    
    
    //on keyboard alpha1 pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawn();
        }
    }
    
}
