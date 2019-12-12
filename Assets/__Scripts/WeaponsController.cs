using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class WeaponsController : MonoBehaviour
{
    // spawn the bullets when the user hits the space bar
    // give the bullets a speed, and an upwards direction (Vector2(0,1))
    public GameObject bulletPrefab;
    public Transform FirePoint;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // need a method to create bullet
    // use invokeRepeating rather CoRoutine
    private void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    

}
