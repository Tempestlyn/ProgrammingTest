using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionButton : MonoBehaviour
{
    public TankCustomization CustomizationManager;
    public Weapon Weapon;
    public GameObject SelectedUI;
    public bool DefaultSelection;

    private void Start()
    {
        if (DefaultSelection)
        {
            SelectWeapon();
        }
    }


    private void SetSelected()
    {
        CustomizationManager.SelectedWeapons.Add(Weapon);
        SelectedUI.SetActive(true);
    }

    private void SetUnselected()
    {
        CustomizationManager.SelectedWeapons.Remove(Weapon);
        SelectedUI.SetActive(false);
    }

    public void SelectWeapon()
    {
        if (CustomizationManager.SelectedWeapons.Count < CustomizationManager.MaxSelectableWeapons && !CustomizationManager.SelectedWeapons.Contains(Weapon))
        {
            SetSelected();
        }
        else if (CustomizationManager.SelectedWeapons.Contains(Weapon))
        {
            SetUnselected();
        }
    }
}
