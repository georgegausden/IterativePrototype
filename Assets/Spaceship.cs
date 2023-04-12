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
    public float fuelConsumptionRate = 0.05f; // rate at which fuel is consumed per second
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate fuel consumption rate based on current velocity
        float fuelConsumption = rb.velocity.magnitude * fuelConsumptionRate * Time.deltaTime;

        // Check if forward or backward key is pressed and adjust fuel consumption rate
        if (Input.GetKey(forwardKey))
        {
            fuelConsumption *= 2f; // consume fuel at double the rate when moving forward
        }
        else if (Input.GetKey(backwardKey))
        {
            fuelConsumption *= 0.5f; // consume fuel at half the rate when moving backward
        }

        // Subtract fuel consumption from energy left
        EnergyLeft -= fuelConsumption;

        // Clamp energy left to be between 0 and maxEnergy
        EnergyLeft = Mathf.Clamp(EnergyLeft, 0f, maxEnergy);
    }
}
