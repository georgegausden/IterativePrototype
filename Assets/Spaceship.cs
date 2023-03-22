using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    public float thrustSpeed = 10;
    public float rollSpeed = 10;
    public float EnergyLeft = 100;
    public float maxEnergy = 100;
    //public Text velocityText;
    //public Text accelerationText;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get velocity and acceleration
        //Vector3 velocity = rb.velocity;
        //Vector3 acceleration = rb.velocity - rb.velocity.normalized * rb.drag;

        // Display velocity and acceleration in front of the user
        //velocityText.text = "Velocity: x=" + velocity.x.ToString("0.00") + ", y=" + velocity.y.ToString("0.00") + ", z=" + velocity.z.ToString("0.00");
        //accelerationText.text = "Acceleration: x=" + acceleration.x.ToString("0.00") + ", y=" + acceleration.y.ToString("0.00") + ", z=" + acceleration.z.ToString("0.00");
    }
}
