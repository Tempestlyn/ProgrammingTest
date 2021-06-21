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


    public void SetSelected()
    {
        CustomizationManager.SelectedWeapons.Add(Weapon);
        SelectedUI.SetActive(true);
    }

    public void SetUnselected()
    {
        CustomizationManager.SelectedWeapons.Remove(Weapon);
        SelectedUI.SetActive(false);
    }

    public void SelectWeapon()
    {
        CustomizationManager.DisplayInfo(Weapon.Name, Weapon.Description);
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
