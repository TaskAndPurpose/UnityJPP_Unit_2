using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    // Variables
    public bool _bMoveTowardsTarget = true; // Indicates whether the enemy should move towards a target
    public Transform target; // The target the enemy should move towards
    public float speed = 5f; // The speed at which the enemy moves
    
    //comp
    [FormerlySerializedAs("playerHealth")] public Health myHealth;

    // Method to move towards the target
    private void MoveTowardsTarget()
    {
        GetTargetPosition();
        // Move towards the target's position at a constant speed
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }
    
    
    // get the target postion
    
    private Transform GetTargetPosition()
    {
        // Get the player's position
        target = GameObject.FindGameObjectWithTag("Player").transform;
        return target;
    }
    
    
    
    // Unity Update method is called once per frame
    private void Update()
    {
        // Move towards the target if it's not null and the option to move towards target is enabled
        if (target != null && _bMoveTowardsTarget)
        {
            MoveTowardsTarget();
        }
    }
    
    private bool _bFollowDeBounce = true;
    private float _followDeBounceTime = 2.5f;

    IEnumerator FollowPlayerDebounce(float time)
    {
        Debug.Log("FollowPlayerDebounce coroutine started");
        _bFollowDeBounce = false;
        _bMoveTowardsTarget = false;
        yield return new WaitForSeconds(time);
        _bMoveTowardsTarget = true;
        _bFollowDeBounce = true;
        Debug.Log("FollowPlayerDebounce coroutine finished");
    }
    
    
    // Trigger method called when this object enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {


            Debug.Log("OnTriggerEnter called");
            if (_bFollowDeBounce)
            {
                StartCoroutine(FollowPlayerDebounce(_followDeBounceTime));

                // Check if the object entered is tagged as "Player"
                if (other.CompareTag("Player"))
                {
                    Debug.Log("Enemy hit the player!");
                    // Attempt to get the Health component from the collided object
                    Health playerHealth = other.GetComponent<Health>();
                    // Check if the Health component exists
                    if (playerHealth != null)
                    {
                        // Reduce the player's health
                        playerHealth.TakeDamage(0.2f);
                    }
                    else
                    {
                        // Log a warning if the Health component is missing
                        Debug.LogWarning("Player object does not have a Health component!");
                    }
                }
            }
            
        }

    }
}