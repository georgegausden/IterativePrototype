using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    
    public Spaceship spaceship;
    TMP_Text fuelText;

    private void Start()
    {
        fuelText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float fuelLevel = spaceship.EnergyLeft / spaceship.maxEnergy;
        fuelText.text = "Fuel: " + (fuelLevel * 100).ToString("0") + "%";
    }
}
