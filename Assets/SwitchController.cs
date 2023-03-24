using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject player;
    public GameObject rocket;

    private FirstPersonController playerController;
    private RocketController rocketController;
    private Camera playerCamera;
    private Camera rocketCamera;
    

    private void Start()
    {
        // Find the player controller and rocket controller components
        playerController = player.GetComponent<FirstPersonController>();
        rocketController = rocket.GetComponent<RocketController>();

        // Find the player camera and rocket camera components
        playerCamera = player.GetComponentInChildren<Camera>();
        rocketCamera = rocket.GetComponentInChildren<Camera>();

        // Disable the rocket controller and camera by default
        rocketController.enabled = false;
        rocketCamera.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && player.GetComponent<FuelCellCollector>().HasAllFuelCells)
        {
            
            // Disable player control and enable rocket control
            playerController.enabled = false;
            rocketController.enabled = true;

            // Set the player as a child of the rocket so they move together
            player.transform.SetParent(rocket.transform);

            // Disable player camera and enable rocket camera
            playerCamera.enabled = false;
            rocketCamera.enabled = true;

            // Set the rocket camera as the main camera
            Camera.main.transform.SetParent(rocketCamera.transform);
            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.localRotation = Quaternion.identity;
        }
    }
}
