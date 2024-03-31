using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;
    Vector3 normal;
    Vector3 contact;
    [SerializeField]GameObject fx;

    private void OnCollisionEnter(Collision collision)
    {
        status = "collision enter" + collision.gameObject.name;
        contact = collision.contacts[0].point;
        normal = collision.GetContact(0).normal;
        Instantiate(fx, contact, Quaternion.LookRotation(Vector3.up, normal));
        
    }
    private void OnCollisionStay(Collision collision)
    {
        status = "collision Stay" + collision.gameObject.name;

    }
    private void OnCollisionExit(Collision collision)
    {
        status = "collision Exit" + collision.gameObject.name;
    }
    private void OnTriggerEnter(Collision collision)
    {
        status = "trigger enter" + collision.gameObject.name;

    }
    private void OnTriggerStay(Collision collision)
    {

        status = "trigger Stay" + collision.gameObject.name;
    }
    private void OnTriggerExit(Collision collision)
    {
        status = "trigger Exit" + collision.gameObject.name;

    }
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x / 2, Screen.height - screen.y / 2, 250, 70), status);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(contact, 0.1f);
        Gizmos.DrawLine(contact, contact + normal);

    }


}
