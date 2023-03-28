using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationRocketBeginning : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    public float acceleration = 2f;
    private float timer = 5f;
    private bool isMovingForward = true;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (isMovingForward)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else
        {
            isMovingForward = false;
            Vector3 targetDirection = target.transform.position - transform.position;
            targetDirection.y = 0f; // Optional: lock onto the same height
            transform.rotation = Quaternion.LookRotation(targetDirection);
            speed += acceleration * Time.deltaTime;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
