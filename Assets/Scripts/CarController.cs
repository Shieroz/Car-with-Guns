using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    float throttle, steer;

    public GameObject[] wheelMeshes;
    public WheelCollider[] throttleWheels;
    public GameObject[] steerWheels;

    public float throttleStrength = 3000f;
    public float steerStrength = 20f;

    public Transform CM;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CM.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = throttleStrength * Time.fixedDeltaTime * throttle;
        }

        foreach (GameObject mesh in wheelMeshes)
        {
            //Fix this when replacing this with an actual wheel model since the rotation of the mesh is 90 in z-axis right now
            mesh.transform.Rotate(0f, rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0? -1 : 1) / (2 * Mathf.PI * 0.28f), 0f);
        }

        foreach (GameObject wheel in steerWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = steerStrength * steer;
            wheel.transform.localEulerAngles = new Vector3(0f, steerStrength * steer, 0f);
        }

    }
}
