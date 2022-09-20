using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Car {
    public class CarControl : MonoBehaviour
    {

        private float m_horizontalInput, m_verticalInput, m_steeringAngle;

        public WheelCollider frontRightC, frontLeftC;
        public WheelCollider rearRightC, rearLeftC;

        public Transform frontRightT, frontLeftT;
        public Transform  rearRightT, rearLeftT;

        public float maxSteeringAngle = 30;
        public float motorForce = 50;
        public float maxSpeed = 50;
        public float brakeForce = 20;

        private float currentSpeed;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            GetInput();
            Steer();
            Accelerate();
            Brake();
            UpdateWheelPoses();
        }
        public void GetInput()
        {
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");
        }

        private void Steer()
        {
            m_steeringAngle = m_horizontalInput * maxSteeringAngle;

            frontLeftC.steerAngle = m_steeringAngle;
            frontRightC.steerAngle = m_steeringAngle;
        }

        private void Accelerate()
        {
            currentSpeed = rb.velocity.sqrMagnitude;

            if(m_verticalInput != 0 && currentSpeed < maxSpeed)
            {
                frontLeftC.motorTorque = m_verticalInput * motorForce;
                frontRightC.motorTorque = m_verticalInput * motorForce;
            }
            else
            {
                frontLeftC.motorTorque = 0;
                frontRightC.motorTorque = 0;
            }
        }

        private void Brake()
        {
            frontLeftC.brakeTorque = Input.GetAxis("Jump") * brakeForce;
            frontRightC.brakeTorque = Input.GetAxis("Jump") * brakeForce;
        }

        private void UpdateWheelPoses()
        {
            UpdateWheelPose(frontLeftC, frontLeftT);
            UpdateWheelPose(frontRightC, frontRightT);
            UpdateWheelPose(rearLeftC, rearLeftT);
            UpdateWheelPose(rearRightC, rearRightT);
        }

        private void UpdateWheelPose (WheelCollider _collider, Transform _transform)
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;

            _collider.GetWorldPose(out pos, out rot);

            _transform.position = pos;
            _transform.rotation = rot;
        }

    }
}