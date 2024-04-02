using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public int points = 100; // Points awarded for hitting this block
    public GameObject hitEffectPrefab; // Assign a hit effect prefab in the inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere")) 
        {
            ScoreManager.AddPoints(points);

            // Instantiate the hit effect at the point of collision
            // The rotation is set to Quaternion.identity to keep the effect's default rotation
            Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);

            Destroy(gameObject); 
        }
    }
}
