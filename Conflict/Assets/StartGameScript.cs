using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartGameScript : MonoBehaviour
{

    public GameObject CustomizationUI;

    public TankCustomization Player1Customization;
    public TankCustomization Player2Customization;

    public GameObject Player1StartingPosition;
    public GameObject Player2StartingPosition;

    public LevelController levelController;


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
        if (Player1Customization.SelectedWeapons.Count != 0 && Player2Customization.SelectedWeapons.Count != 0)
        {
            levelController.Player1Customization = Player1Customization;
            levelController.Player2Customization = Player2Customization;
            levelController.SpawnPlayers();
            CustomizationUI.SetActive(false);
            levelController.Player1ActiveWeaponText.gameObject.SetActive(true);
            levelController.Player2ActiveWeaponText.gameObject.SetActive(true);
        }
    }
}
