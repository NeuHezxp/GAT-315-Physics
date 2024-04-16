using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscan : MonoBehaviour
{
    [SerializeField] float distance = 10;
    [SerializeField] GameObject hitPrefab;

    [SerializeField] LayerMask layermask = Physics.AllLayers;

    private void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, layermask))
        {
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            }
        }

        Destroy(gameObject);
    }
}
