using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Range(1, 10)] float playerSpeed = 2.0f;
    [SerializeField, Range(1, 10)] float jumpHeight = 1.0f;
    [SerializeField] float pushPower = 2.0f;
    [SerializeField] float rotationRate = 2.0f;
    [SerializeField] Transform cameraView;
    private CharacterController controller;
    private Vector3 velocity;
    private bool onGround;
    public Animator animator; // Reference to the Animator component

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); // Initialize the Animator component
    }

    void Update()
    {
        onGround = controller.isGrounded;
        if (onGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1); // makes diagonals the same speed as directionals

        // puts us in view space
        move = Quaternion.Euler(0, cameraView.rotation.eulerAngles.y, 0) * move;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * rotationRate);
        }

        // Updating Animator parameters
        animator.SetFloat("Speed", velocity.magnitude);
        animator.SetFloat("YVal", velocity.y);
        animator.SetBool("OnGround", onGround);
       
        // animator.SetBool("Equipped", isEquipped);

        // Jumping
        if (Input.GetButtonDown("Jump") && onGround)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.AddForce(pushDir * pushPower, ForceMode.VelocityChange);
    }
}
