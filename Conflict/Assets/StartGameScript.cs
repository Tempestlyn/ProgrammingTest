using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{

    public GameObject CustomizationUI;

    public TankCustomization Player1Customization;
    public TankCustomization Player2Customization;

    public GameObject Player1StartingPosition;
    public GameObject Player2StartingPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        var player1 = Instantiate(Player1Customization.TankPrefab, Player1StartingPosition.transform).GetComponent<PlayerTank>();
        Player1Customization.SelectedTread.ApplyTankBodyData(player1);
        Player1Customization.SelectedHull.ApplyTankBodyData(player1);
        player1.gameObject.GetComponent<SpriteRenderer>().sprite = Player1Customization.SelectedSprite;
        for(var i = 0; i < Player1Customization.SelectedWeapons.Count; i++)
        {
            player1.Weapons.Add(Player1Customization.SelectedWeapons[i]);
        }


        var player2 = Instantiate(Player2Customization.TankPrefab, Player2StartingPosition.transform).GetComponent<PlayerTank>();
        Player2Customization.SelectedTread.ApplyTankBodyData(player2);
        Player2Customization.SelectedHull.ApplyTankBodyData(player2);
        player2.gameObject.GetComponent<SpriteRenderer>().sprite = Player2Customization.SelectedSprite;
        for (var i = 0; i < Player2Customization.SelectedWeapons.Count; i++)
        {
            player2.Weapons.Add(Player2Customization.SelectedWeapons[i]);
        }


        CustomizationUI.SetActive(false);
        
    }
}
