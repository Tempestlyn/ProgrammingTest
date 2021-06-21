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

    public bool RoundEnded;

    public int Player1Score;
    public int Player2Score;
    private void Start()
    {
        GenerateMap();
    }

    public void Refresh()
    {
        RoundEnded = false;
        SpawnedObjects = 0;
        Destroy(Player1Tank.gameObject);
        Destroy(Player2Tank.gameObject);
        for (var i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnPoints[i].Clear();
        }
        DestroyObjects();
        GenerateMap();
        SpawnPlayers();
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
        Player1Tank.levelController = this;
        Player1Customization.SelectedTread.ApplyTankBodyData(Player1Tank);
        Player1Customization.SelectedHull.ApplyTankBodyData(Player1Tank);
        Player1Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player1Customization.SelectedSprite;
        for (var i = 0; i < Player1Customization.SelectedWeapons.Count; i++)
        {
            Player1Tank.Weapons.Add(Player1Customization.SelectedWeapons[i]);
        }


        Player2Tank = Instantiate(Player2Customization.TankPrefab, Player2StartingPosition.transform).GetComponent<PlayerTank>();
        Player2Tank.PlayerNumber = Player.Player2;
        Player2Tank.levelController = this;
        Player2Customization.SelectedTread.ApplyTankBodyData(Player2Tank);
        Player2Customization.SelectedHull.ApplyTankBodyData(Player2Tank);
        Player2Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player2Customization.SelectedSprite;
        for (var i = 0; i < Player2Customization.SelectedWeapons.Count; i++)
        {
            Player2Tank.Weapons.Add(Player2Customization.SelectedWeapons[i]);
        }
    }

    void DestroyObjects()
    {
        var bullets = FindObjectsOfType<Bullet>();
        Debug.Log(bullets.Length);
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        var prefabs = FindObjectsOfType<DestroyOnRefresh>();
        Debug.Log(prefabs.Length);
        for (int i = 0; i < prefabs.Length; i++)
        {
            Destroy(prefabs[i].gameObject);
        }
    }
}
