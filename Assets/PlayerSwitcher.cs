using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player;
    public Vector3 newObjectPosition;
    public Quaternion newObjectRotation;
    public MeshFilter playerMeshFilter;
    public Collider playerCollider;
    public bool IsRocket = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Playable"))
        {

            //store the mesh info of the object
            Mesh newObjectMesh = collision.gameObject.GetComponent<MeshFilter>().mesh;
            playerMeshFilter.mesh = newObjectMesh;

            //switch the collider of the object
            Collider newObjectCollider = collision.gameObject.GetComponent<Collider>();

            transform.localScale = collision.transform.localScale;


            if (newObjectCollider is BoxCollider)
            {
                Destroy(playerCollider);
                playerCollider = gameObject.AddComponent<BoxCollider>();
            }
            else if (newObjectCollider is SphereCollider)
            {
                Destroy(playerCollider);
                playerCollider = gameObject.AddComponent<SphereCollider>();
            }

            // Get the mesh and material of the collided object
            Mesh mesh = collision.gameObject.GetComponent<MeshFilter>().sharedMesh;
            Material material = collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial;

            // Set the mesh and material of the player object to match the collided object
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshFilter.mesh = mesh;
            meshRenderer.sharedMaterial = material;


            IsRocket = true;



            //Transform newObjectTransform = collision.transform;
            //newObjectPosition = newObjectTransform.position;
            //newObjectRotation = newObjectTransform.rotation;



            //transform.position = newObjectPosition;
            //transform.rotation = newObjectRotation;

            //remove the old object
            Destroy(collision.gameObject);

            this.GetComponent<AudioSource>().Play();

            //swap the objects

        }
    }

}
