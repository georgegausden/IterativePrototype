using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spaceshipController : MonoBehaviour
{
    public Spaceship spaceship; // A scriptable object that holds data for the spaceship
    public float mouseSensitivity = 100f; // How fast the spaceship rotates with mouse movement

    private Rigidbody rb; // The rigidbody component of the spaceship
    private float thrust; // The current thrust value
    private float pitch; // The pitch angle of the spaceship
    private float yaw; // The yaw angle of the spaceship
    private float roll; // The roll angle of the spaceship

    public string newSceneName; //landing on a planet

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the rigidbody component
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    private void Update()
    {
        // Get input values from keyboard and mouse
        thrust = Input.GetAxis("Vertical") * spaceship.thrustSpeed * Time.deltaTime;
        pitch = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yaw = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        roll = -Input.GetAxis("Horizontal") * spaceship.rollSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // Apply forces and torques to the rigidbody based on input values
        rb.AddRelativeForce(Vector3.forward * thrust);
        rb.AddRelativeTorque(pitch, yaw, roll);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TrackingObject"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
