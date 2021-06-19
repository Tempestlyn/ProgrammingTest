using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public int NumberofObjectsToSpawn;
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
    private int SpawnedObjects;

    private void Start()
    {
        for(var i = 0; i < NumberofObjectsToSpawn; i++)
        {
            if (SpawnedObjects < SpawnPoints.Count)
            {
                GetOpenSpawnPoint().SpawnObject();
                SpawnedObjects += 1;
            }
        }
    }

    public SpawnPoint GetOpenSpawnPoint()
    {
        var point = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        if (point.Filled)
        {
            return GetOpenSpawnPoint();
        }
        else
        {
            return point;
        }
    }
}
