using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    public int sceneIndexToLoad = 0; // The index of the scene to load on touch

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched this one was the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the scene with the specified index
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
