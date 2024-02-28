using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    
    public Rigidbody _rb;
    public float _bulletSpeed = 250;
    public int _timeTillDestroy = 10;
    
    void OnHitTarget()
    {
        //destroy self
        Destroy(this.GameObject(), 0.1f);
    }
    
    void Start()
    {
        //destroy self
        Destroy(this.GameObject(), _timeTillDestroy);
        
        
        // _gameMode = GameObject.Find("GameMode").GetComponent<GameModeMain>();
       
        _rb.velocity = transform.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Tango"))
        {
            OnHitTarget();
            Debug.Log("Hit Tango");
            //get comp health
            other.gameObject.GetComponent<Health>().TakeDamage(.2f);
        }
    }
    
}