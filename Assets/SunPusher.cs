using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPusher : MonoBehaviour
{
    public float maxDistanceFromSun = 100f;
    public float pushForce = 100f;

    private GameObject sun;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
        sun = GameObject.FindWithTag("Sun");

        // Check if the player is too close to the sun
        if (Vector3.Distance(transform.position, sun.transform.position) < maxDistanceFromSun)
        {
            Debug.Log("close");
            // Calculate the direction from the player to the sun
            Vector3 direction = transform.position - sun.transform.position;

            // Apply an instant force to the player in the opposite direction that they are travelling in
            GetComponent<Rigidbody>().AddForce(direction.normalized * pushForce);
        }
    }
}