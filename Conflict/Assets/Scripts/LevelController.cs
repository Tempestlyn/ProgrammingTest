using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public int ScoreNeededToWin;

    public TextMeshProUGUI Player1ActiveWeaponText;
    public TextMeshProUGUI Player2ActiveWeaponText;

    public Scoreboard Scoreboard;

    private void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scoreboard.gameObject.SetActive(!Scoreboard.gameObject.activeSelf);
            Scoreboard.UpdatePlayerScores(Player1Score, Player2Score);
        }
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

        if (Player1Score >= ScoreNeededToWin)
        {
            Scoreboard.gameObject.SetActive(true);
            Scoreboard.UpdatePlayerScores(Player1Score, Player2Score);
            Scoreboard.DeclareWinner(Scoreboard.Player1WinString);

        }
        else if (Player2Score >= ScoreNeededToWin)
        {
            Scoreboard.gameObject.SetActive(true);
            Scoreboard.UpdatePlayerScores(Player1Score, Player2Score);
            Scoreboard.DeclareWinner(Scoreboard.Player2WinString);
        }
        else
        {
            DestroyObjects();
            GenerateMap();
            SpawnPlayers();
        }
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
        //checks if spawn point has already instantiated an object
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

    public void IncreasePlayerScore(Player player)
    {
        if(player == Player.Player1)
        {
            Player1Score += 1;
        }
        else
        {
            Player2Score += 1;
        }
    }

    public void SpawnPlayers()
    {
        //Instantiates both players with their selected parts
        Player1Tank = Instantiate(Player1Customization.TankPrefab, Player1StartingPosition.transform).GetComponent<PlayerTank>();
        Player1Tank.PlayerNumber = Player.Player1;
        Player1Tank.levelController = this;
        Player1Customization.SelectedTread.ApplyTankTreadData(Player1Tank);
        Player1Customization.SelectedHull.ApplyTankBodyData(Player1Tank);
        Player1Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player1Customization.SelectedSprite;
        for (var i = 0; i < Player1Customization.SelectedWeapons.Count; i++)
        {
            Player1Tank.Weapons.Add(Player1Customization.SelectedWeapons[i]);
        }
        Player1ActiveWeaponText.text = Player1Tank.Weapons[Player1Tank.ActiveWeapon].Name;

        Player2Tank = Instantiate(Player2Customization.TankPrefab, Player2StartingPosition.transform).GetComponent<PlayerTank>();
        Player2Tank.PlayerNumber = Player.Player2;
        Player2Tank.levelController = this;
        Player2Customization.SelectedTread.ApplyTankTreadData(Player2Tank);
        Player2Customization.SelectedHull.ApplyTankBodyData(Player2Tank);
        Player2Tank.gameObject.GetComponent<SpriteRenderer>().sprite = Player2Customization.SelectedSprite;
        for (var i = 0; i < Player2Customization.SelectedWeapons.Count; i++)
        {
            Player2Tank.Weapons.Add(Player2Customization.SelectedWeapons[i]);
        }
        Player2ActiveWeaponText.text = Player2Tank.Weapons[Player2Tank.ActiveWeapon].Name;
    }

    void DestroyObjects()
    {
        //Destroys leftover objects when refreshing the map, specifically bullets and anything with a DestroyOnRefresh component
        var bullets = FindObjectsOfType<Bullet>();
        Debug.Log(bullets.Length);
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        var prefabs = FindObjectsOfType<DestroyOnRefresh>();
        for (int i = 0; i < prefabs.Length; i++)
        {
            Destroy(prefabs[i].gameObject);
        }
    }

    
    
}
