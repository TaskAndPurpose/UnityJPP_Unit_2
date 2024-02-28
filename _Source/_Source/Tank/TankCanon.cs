using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCanon : MonoBehaviour
{
    // upon pressing fire, instantiate a bullet

    public GameObject bulletPrefab;
    public Transform firePoint;


    public void Fire()
    {
        // create bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Check if the F key is pressed down
        {
            Debug.Log("Fire!");
            Fire();
        }
    }
}
