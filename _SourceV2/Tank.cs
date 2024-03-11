using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Movement and firing settings
    public float speed = 12f;
    public float turnSpeed = 180f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Firing input
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }

        // Process rotation and movement
        Move(vertical);
        Turn(horizontal);
    }

    private void Move(float input)
    {
        Vector3 movement = transform.forward * input * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn(float input)
    {
        float turn = input * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Fire!");
    }
}
