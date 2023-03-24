
using System.Collections;
using UnityEngine;

public class Beeper : MonoBehaviour
{
    public AudioClip audioClip;
    public float maxDistance = 30f;
    public float minDistance = 5f;
    public float maxPlaybackInterval = 5f;
    public float minPlaybackInterval = 1f;

    private AudioSource audioSource;
    private Transform playerTransform;
    private float distanceToPlayer;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.spatialBlend = 1; // 3D sound
        audioSource.playOnAwake = false;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(PlayAudioBasedOnDistance());
    }

    IEnumerator PlayAudioBasedOnDistance()
    {
        while (true)
        {
            distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

            if (distanceToPlayer <= maxDistance)
            {
                float distanceFactor = Mathf.Clamp01((distanceToPlayer - minDistance) / (maxDistance - minDistance));
                float playbackInterval = Mathf.Lerp(minPlaybackInterval, maxPlaybackInterval, distanceFactor);
                audioSource.Play();
                yield return new WaitForSeconds(playbackInterval);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
