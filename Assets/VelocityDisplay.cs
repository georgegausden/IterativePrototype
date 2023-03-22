using UnityEngine;
using TMPro;

public class VelocityDisplay : MonoBehaviour
{
    Rigidbody playerRigidbody;
    TMP_Text velocityText;

    void Start()
    {
        // Get the Rigidbody component of the player GameObject
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        // Get the TextMeshPro Text component attached to the same GameObject as this script
        velocityText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Get the current velocity and acceleration of the player Rigidbody
        Vector3 velocity = playerRigidbody.velocity;
        Vector3 acceleration = (playerRigidbody.velocity - playerRigidbody.velocity) / Time.deltaTime;

        // Update the text displayed with the velocity and acceleration
        velocityText.text = "Velocity: " + velocity.ToString("F2") + "\n" +
                            "Acceleration: " + acceleration.ToString("F2");
    }
}
