using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 10f;
    public float mouseSensitivity = 100f;
    private PlayerSwitcher playerSwitcher;
    private Rigidbody rb;
    private FirstPersonController firstPersonController;
    private float xRotation = 0f;

    void Start()
    {
        playerSwitcher = GetComponent<PlayerSwitcher>();
        rb = GetComponent<Rigidbody>();
        firstPersonController = GetComponent<FirstPersonController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (playerSwitcher.IsRocket)
        {
            // Remove FirstPersonController script
            Destroy(firstPersonController);

            // Disable gravity and set velocities to 0
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Implement rocket behavior here
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 horizontalMovement = new Vector3(horizontalInput, 0, 0);
            rb.AddForce(horizontalMovement * speed);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * speed);
            }

            // Implement camera panning here
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}