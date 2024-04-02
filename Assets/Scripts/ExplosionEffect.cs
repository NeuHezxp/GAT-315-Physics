using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float explosionForce = 1000f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 0.4f;
    public KeyCode explosionKey = KeyCode.Mouse1; // Set the key to trigger the explosion

    void Update()
    {
        // Check if the explosion key is pressed
        if (Input.GetKeyDown(explosionKey))
        {
            Explode();
        }
    }

    void Explode()
    {
        // Find all colliders within the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            // If the collider has a Rigidbody, add an explosion force
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Set the color of the Gizmo
        Gizmos.color = new Color(1, 0, 0, 0.5f); // Semi-transparent red

        // Draw a sphere representing the explosion radius
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
