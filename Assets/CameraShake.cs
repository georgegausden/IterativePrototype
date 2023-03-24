using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.1f;

    private Vector3 originalPosition;
    private float shakeTimer;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartShake();
        }

        if (shakeTimer > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = originalPosition;
        }
    }

    private void StartShake()
    {
        originalPosition = transform.localPosition;
        shakeTimer = shakeDuration;
    }
}
