using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject player;
    private GameObject currentController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            currentController = other.gameObject;
            player.transform.parent = currentController.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            player.transform.parent = null;
        }
    }

   
}