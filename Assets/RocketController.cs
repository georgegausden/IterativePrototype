using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public float thrust = 5.0f;
    public float targetHeight = 300.0f;
    public float maxVolumeDistance = 10.0f;
    public AudioClip rocketSound;

    private Rigidbody rb;
    private AudioSource audioSource;
    private bool playerCollided = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = rocketSound;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    private void FixedUpdate()
    {
        if (playerCollided && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * thrust, ForceMode.Force);

            // Calculate the volume of the audio based on the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            float volume = Mathf.Clamp01(1.0f - distanceToPlayer / maxVolumeDistance);

            audioSource.volume = volume;

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        // Check if the rocket has reached the target height
        if (transform.position.y >= targetHeight)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollided = false;
            audioSource.Stop();
        }
    }
}
