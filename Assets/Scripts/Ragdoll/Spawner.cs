using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private KeyCode spawnKey = KeyCode.Space; 

    void Update()
    {
        
        if (Input.GetKeyDown(spawnKey))
        {
            
            Instantiate(ragdoll, transform.position, transform.rotation);
        }
    }
}
