using UnityEngine;

public class FuelCellCollector : MonoBehaviour
{
    public int fuelCellsCollected = 0;
    public bool HasAllFuelCells = false;
    public int fuelCellsToCollect = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FuelCell"))
        {
            fuelCellsCollected++;
            Destroy(other.gameObject);
        }
    }

    
    void FixedUpdate()
    {
        if (fuelCellsCollected >= fuelCellsToCollect)
        {
            
            HasAllFuelCells = true;
        }
    }
}
