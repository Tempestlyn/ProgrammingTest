using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int NumberofObjectsToSpawn;
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
    private int SpawnedObjects;

    public GameObject Player1StartingPosition;
    public GameObject Player2StartingPosition;

    public PlayerTank Player1Tank;
    public PlayerTank Player2Tank;

    public TankCustomization Player1Customization;
    public TankCustomization Player2Customization;

    private void Start()
    {
        GenerateMap();
    }

    public void Refresh()
    {
        Destroy(Player1Tank.gameObject);
        Destroy(Player2Tank.gameObject);
        for (var i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnPoints[i].Clear();
        }

        GenerateMap();
        

    }

    public void GenerateMap()
    {
        for (var i = 0; i < NumberofObjectsToSpawn; i++)
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

    public void SpawnPlayers()
    {
        Player1Tank = Instantiate(Player1Customization.TankPrefab, Player1StartingPosition.transform).GetComponent<PlayerTank>();
        Player1Tank.PlayerNumber = Player.Player1;
        Player1Customization.SelectedTread.ApplyTankBodyData(Player1Tank);
        Player1Customization.SelectedHull.ApplyTankBodyData(Player1Tank);
        Player1Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player1Customization.SelectedSprite;
        for (var i = 0; i < Player1Customization.SelectedWeapons.Count; i++)
        {
            Player1Tank.Weapons.Add(Player1Customization.SelectedWeapons[i]);
        }


        Player2Tank = Instantiate(Player2Customization.TankPrefab, Player2StartingPosition.transform).GetComponent<PlayerTank>();
        Player2Tank.PlayerNumber = Player.Player2;
        Player2Customization.SelectedTread.ApplyTankBodyData(Player2Tank);
        Player2Customization.SelectedHull.ApplyTankBodyData(Player2Tank);
        Player2Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player2Customization.SelectedSprite;
        for (var i = 0; i < Player2Customization.SelectedWeapons.Count; i++)
        {
            Player2Tank.Weapons.Add(Player2Customization.SelectedWeapons[i]);
        }
    }
}
