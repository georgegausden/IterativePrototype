using UnityEngine;
using UnityEngine.UI;

public class PlanetInteractionUI : MonoBehaviour
{
    public GameObject planet; // The planet the player has collided with
    public GameObject uiElementPrefab; // The prefab for the UI element

    private GameObject uiElement; // The instance of the UI element
    private Button landButton; // The button for landing on the planet
    private Button leaveButton; // The button for leaving the planet

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == planet)
        {
            // Create the UI element prefab
            uiElement = Instantiate(uiElementPrefab, transform);

            // Get references to the buttons in the UI element
            landButton = uiElement.transform.Find("LandButton").GetComponent<Button>();
            leaveButton = uiElement.transform.Find("LeaveButton").GetComponent<Button>();

            // Add event listeners to the buttons
            landButton.onClick.AddListener(LandOnPlanet);
            leaveButton.onClick.AddListener(LeavePlanet);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == planet)
        {
            // Destroy the UI element instance
            Destroy(uiElement);
        }
    }

    private void LandOnPlanet()
    {
        Debug.Log("Player has chosen to land on the planet.");
    }

    private void LeavePlanet()
    {
        Debug.Log("Player has chosen to leave the planet.");
    }
}
