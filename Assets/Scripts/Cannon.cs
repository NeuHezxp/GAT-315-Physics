using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public CameraManager cameraManager;

    public GameObject spherePrefab; 
    public Transform shootPoint; 
    public float shootForce = 1000f;
    public GameObject fireFx;
    public AudioClip ShootClip;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
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

        if (fireFx != null)
        {
            Instantiate(fireFx, shootPoint.position, shootPoint.rotation);
        }
        
        if (cameraManager != null)
        {
            cameraManager.TrackObject(cannonBallInstance);
        }
        if (ShootClip != null) AudioSource.PlayClipAtPoint(ShootClip,shootPoint.position);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        

        // Find and notify the CameraManager to stop tracking
        CameraManager cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
        {
            cameraManager.StopTracking();
        }
    }

}
