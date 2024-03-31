using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public struct Wheel
    {
        public WheelCollider collider;
    }

    [System.Serializable]
    public struct Axle
    {
        public Wheel leftWheel;
        public Wheel rightWheel;
        public bool isMotor;
        public bool isSteering;
    }

    [SerializeField] Axle[] axles;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;

    public void FixedUpdate()
    {
        // Capture vertical axis input and multiply it by maxMotorTorque for acceleration and braking
        float motor = Input.GetAxis("Vertical") * maxMotorTorque;

        // Capture horizontal axis input and multiply it by maxSteeringAngle for steering
        float steering = Input.GetAxis("Horizontal") * maxSteeringAngle;

        foreach (Axle axle in axles)
        {
            if (axle.isSteering)
            {
                axle.leftWheel.collider.steerAngle = steering;
                // Set axle right wheel collider steer angle
                axle.rightWheel.collider.steerAngle = steering;
            }
            if (axle.isMotor)
            {
                axle.leftWheel.collider.motorTorque = motor;
                // Set axle right wheel collider motor torque
                axle.rightWheel.collider.motorTorque = motor;
            }
        }
    }
}
