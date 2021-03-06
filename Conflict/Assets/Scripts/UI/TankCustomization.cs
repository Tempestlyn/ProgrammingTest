using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TankCustomization : MonoBehaviour
{
    //This class holds the data given by hull, tread, and weapon selection scripts/buttons

    public GameObject TankPrefab;

    public List<Weapon> SelectedWeapons;
    public TankHull SelectedHull;
    public TankTread SelectedTread;
    public Sprite SelectedSprite;

    public int MaxSelectableWeapons;

    public List<HullSelectionButton> HullSelectionButtons = new List<HullSelectionButton>();
    public List<TreadSelection> TreadSelectionButtons = new List<TreadSelection>();
    public List<GunSelectionButton> gunSelectionButtons = new List<GunSelectionButton>();
    public List<ColorSelection> ColorSelectionButtons = new List<ColorSelection>();

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;


    public void DisplayInfo(string name, string description)
    {
        Name.text = name;
        Description.text = description;
    }
}
