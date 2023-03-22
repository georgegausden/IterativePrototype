using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float rotateSpeed = 10f; // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the object around its own axis
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
