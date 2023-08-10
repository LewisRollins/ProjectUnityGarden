using UnityEngine;

public enum SeedType
{
    Type1,
    Type2,
    Type3,
    Type4,
    Type5
}

public class Seed : MonoBehaviour
{
    public SeedType seedType;

    private bool isPlanted = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Allow physics simulation
    }

    public bool IsPlanted()
    {
        return isPlanted;
    }

    public GameObject Plant(Transform parent, GameObject plantPrefab)
    {
        isPlanted = true;
        gameObject.SetActive(false);

        GameObject newPlant = Instantiate(plantPrefab, parent);
        newPlant.transform.localPosition = Vector3.zero;

        return newPlant;
    }

    public void DisableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
}