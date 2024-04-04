using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public CameraManager cameraManager;

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
        GameObject cannonBallInstance = Instantiate(spherePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = cannonBallInstance.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = cannonBallInstance.AddComponent<Rigidbody>();
        }
        rb.AddForce(shootPoint.forward * shootForce);

        // Notify CameraManager
        if (cameraManager != null)
        {
            cameraManager.TrackObject(cannonBallInstance);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Your existing collision logic here

        // Find and notify the CameraManager to stop tracking
        CameraManager cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
        {
            cameraManager.StopTracking();
        }
    }

}
