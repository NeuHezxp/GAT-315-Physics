using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    public int points = 100; // Points awarded for hitting this block
    public GameObject hitEffectPrefab; // Assign a hit effect prefab in the inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere") ) 
        {
            ScoreManager.Score += 10;

          
            Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);

            Destroy(gameObject); 
        }
    }
}
