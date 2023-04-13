using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OxygenLeft : MonoBehaviour
{

    public GameObject player;
    TMP_Text oxygenText;
    public float maxOxygen = 100;
    public float oxygenLeft = 100;
    private Rigidbody rb;
    public float oxygenConsumptionRate = 1;
    public int sceneIndexToLoad = 0;



    private void Start()
    {
        oxygenText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float oxygenLevel = oxygenLeft / maxOxygen;
        oxygenText.text = "Oxygen: " + (oxygenLevel * 100).ToString("0") + "%";
 
        // Subtract oxygen consumption from oxygen left
        oxygenLeft -= oxygenConsumptionRate/10;

        // Check if oxygen left has hit 0
        if (oxygenLeft <= 0f)
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
