using UnityEngine;

public class Pot : MonoBehaviour
{
    public GameObject[] plantPrefabs;

    private bool isWatered = false;
    private GameObject currentPlant;

    private void OnTriggerEnter(Collider other)
    {
        Seed seed = other.GetComponent<Seed>();
        if (seed != null && !seed.IsPlanted())
        {
            PlantSeed(seed);
        }
    }

    private bool TryPlantSeed(Seed seed)
    {
        if (seed != null && !seed.IsPlanted())
        {
            PlantSeed(seed);
            return true;
        }
        return false;
    }

    private bool TryWaterPlant(WaterDrop waterDrop)
    {
        if (waterDrop != null && currentPlant != null)
        {
            WaterPlant();
            return true;
        }
        return false;
    }

    private void PlantSeed(Seed seed)
    {
        // Validate the seed's seedType before accessing the plantPrefabs array
        if ((int)seed.seedType >= 0 && (int)seed.seedType < plantPrefabs.Length)
        {
            GameObject prefabToPlant = plantPrefabs[(int)seed.seedType];
            if (prefabToPlant != null)
            {
                currentPlant = seed.Plant(transform, prefabToPlant);
                seed.DisableCollider();
            }
            else
            {
                Debug.LogError("Prefab not assigned for seed type: " + seed.seedType);
            }
        }
        else
        {
            Debug.LogError("Invalid seed type: " + seed.seedType);
        }
    }

    private void WaterPlant()
    {
        isWatered = true;
        // Implement water effects
    }
}
