using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuelRodCounter : MonoBehaviour
{
    public FuelCellCollector fuelCellCollector;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Calculate the number of fuel rods collected over the number of fuel rods necessary
        float fuelRodsCollected = fuelCellCollector.fuelCellsCollected;
        float fuelRodsNeeded = fuelCellCollector.fuelCellsToCollect;
        float fuelRodsRatio = fuelRodsCollected / fuelRodsNeeded;

        // Format the ratio as a percentage
        string fuelRodsRatioText = Mathf.Round(fuelRodsRatio * 100) + "%";

        // Update the text on the UI
        textMeshProUGUI.SetText("Fuel rods collected: " + fuelRodsRatioText);
    }
}
