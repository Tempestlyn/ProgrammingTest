using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<GameObject> SpawnableObjects = new List<GameObject>();
    public bool Filled;

    private GameObject spawnedObject;
    // Start is called before the first frame update

    public void SpawnObject()
    {
        if (SpawnableObjects.Count <= 0)
        {
            Debug.LogError("Spawnpoint has no spawnable objects");
            return;
        }
        var objectToSpawn = SpawnableObjects[Random.Range(0, SpawnableObjects.Count)];
        spawnedObject = Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
        Filled = true;
    }

    public void Clear()
    {
        if (Filled)
        {
            Destroy(spawnedObject);
            Filled = false;
        }
    }
}
