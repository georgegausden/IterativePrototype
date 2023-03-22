using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public Spaceship spaceship; // Assign the Spaceship script in the inspector
    public RectTransform energyBar; // Assign the energy bar RectTransform in the inspector

    private Image energyFill;
    private Image energyBorder;

    void Start()
    {
        // Create the border image
        GameObject borderObject = new GameObject("EnergyBorder");
        borderObject.transform.SetParent(energyBar);
        energyBorder = borderObject.AddComponent<Image>();
        energyBorder.color = Color.white;

        // Set the size and position of the border image
        RectTransform borderTransform = borderObject.GetComponent<RectTransform>();
        borderTransform.anchorMin = new Vector2(0, 0);
        borderTransform.anchorMax = new Vector2(1, 1);
        borderTransform.offsetMin = new Vector2(-2, -2);
        borderTransform.offsetMax = new Vector2(2, 2);

        // Create the fill image
        GameObject fillObject = new GameObject("EnergyFill");
        fillObject.transform.SetParent(borderObject.transform);
        energyFill = fillObject.AddComponent<Image>();
        energyFill.color = Color.green;

        // Set the size and position of the fill image
        RectTransform fillTransform = fillObject.GetComponent<RectTransform>();
        fillTransform.anchorMin = new Vector2(0, 0);
        fillTransform.anchorMax = new Vector2(1, 1);
    }

    void Update()
    {
        // Set the width of the fill image to be equal to its parent width multiplied by (player's current energy divided by their maximum energy)
        float widthRatio = spaceship.EnergyLeft / spaceship.maxEnergy;
        float parentWidth = ((RectTransform)energyFill.transform.parent).rect.width;
        ((RectTransform)energyFill.transform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, parentWidth * widthRatio);
    }
}