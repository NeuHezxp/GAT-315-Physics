using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject spherePrefab; // Assign a prefab of the sphere in the inspector
    public Transform shootPoint; // The point from where the sphere will be shot
    public float shootForce = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Default for left mouse click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the sphere at the shootPoint position and orientation
        GameObject sphere = Instantiate(spherePrefab, shootPoint.position, shootPoint.rotation);

        // Check if the sphere has a Rigidbody component; if not, add one
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = sphere.AddComponent<Rigidbody>();
        }

        // Apply a force to the sphere's Rigidbody in the direction the cannon is aiming
        rb.AddForce(shootPoint.forward * shootForce);
    }
}
