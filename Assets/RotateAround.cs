using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target; // The object to rotate around
    public float speed = 20f; // The speed of rotation

    private void Update()
    {
        // Rotate around the target object at a constant speed
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
