using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaySoundWhenNearSun : MonoBehaviour
{
    public AudioClip soundEffect; // The sound effect to play when near the sun
    public float minDistance = 100f; // The minimum distance required to play the sound effect
    public string sunTag = "Sun"; // The tag of the sun object

    public bool nearSun = false;

    private AudioSource audioSource; // Reference to the audio source component
    private GameObject sunObject; // Reference to the sun object

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sunObject = GameObject.FindGameObjectWithTag(sunTag);
    }

    void Update()
    {
        // Find the nearest object with the "Sun" tag
        GameObject nearestSun = FindNearestWithTag("Sun");

        // Check if the nearest sun is within the specified distance
        if (nearestSun != null && Vector3.Distance(transform.position, nearestSun.transform.position) < minDistance)
        {
            nearSun = true;
            // Play the sound effect if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(soundEffect);
            }
        }
        else
        {
            nearSun = false;
            // Stop the sound effect if it's playing
            audioSource.Stop();
        }
    }

    GameObject FindNearestWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject obj in gameObjects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < nearestDistance)
            {
                nearestObject = obj;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

}

