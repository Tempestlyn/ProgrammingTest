using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCustomization : MonoBehaviour
{

    public Player PlayerNum;
    public Image TankImage;

    public List<Weapon> SelectedWeapons;
    public TankHull SelectedHull;
    public TankTread SelectedTread;

    public int MaxSelectableWeapons;

    public List<HullSelectionButton> HullSelectionButtons = new List<HullSelectionButton>();
    public List<TreadSelection> TreadSelectionButtons = new List<TreadSelection>();

}
