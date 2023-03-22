using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour
{
    //public float pullForce = 10f;
    //public float maxDistance = 5f;

    //void Update()
    //{
    //    // Check for all pullable objects within the max distance
    //    GameObject[] pullableObjects = GameObject.FindGameObjectsWithTag("Actors");
    //    foreach (GameObject obj in pullableObjects)
    //    {
    //        float distance = Vector3.Distance(obj.transform.position, transform.position);

    //        if (distance <= maxDistance)
    //        {
    //            // Calculate the force based on the distance
    //            float force = pullForce * (1f - distance / maxDistance);

    //            // Apply the force towards the player
    //            Vector3 direction = transform.position - obj.transform.position;
    //            obj.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
    //        }
    //    }
    //}
}
