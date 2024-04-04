using UnityEngine;
using System.Collections;

public class Cannonball : MonoBehaviour
{
    public float lifespan = 5f; // The cannonball will exist for 5 seconds before self-destructing

    private void Start()
    {
        StartCoroutine(DestroyAfterLifespan());
    }

    private IEnumerator DestroyAfterLifespan()
    {
        yield return new WaitForSeconds(lifespan);

       
        CameraManager cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
        {
            cameraManager.StopTracking();
        }

        Destroy(gameObject); // Destroy the cannonball after its lifespan has elapsed
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Notify the CameraManager to stop tracking this cannonball
        CameraManager cameraManager = FindObjectOfType<CameraManager>();
        if (cameraManager != null)
        {
            cameraManager.StopTracking();
        }

        // Destroy this cannonball GameObject
        Destroy(gameObject);
    }
}
