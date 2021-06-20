using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TankCustomization : MonoBehaviour
{

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

    public TextMeshPro Name;
    public TextMeshPro Description;
}
