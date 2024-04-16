using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageTarget : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Camera view;
    [SerializeField] float Distance = 5;

    private void LateUpdate() //called after everything else is updated
    {
        Vector3 screen = image.transform.position;
        screen.z = Distance;

       Vector3 world = view.ScreenToWorldPoint(screen);
        transform.position = world;
    }

}
