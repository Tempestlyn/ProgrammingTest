using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullSelectionButton : MonoBehaviour
{
    public TankCustomization CustomizationManager;
    public TankHull Hull;
    public GameObject SelectedUI;
    public bool DefaultSelection;

    private void Start()
    {
        if (DefaultSelection)
        {
            SelectHull();
        }
    }

    private void SetSelected()
    {
        CustomizationManager.SelectedHull = Hull;
        foreach(GunSelectionButton gunSelectionButton in CustomizationManager.gunSelectionButtons)
        {
            if (CustomizationManager.SelectedWeapons.Contains(gunSelectionButton.Weapon))
            {
                gunSelectionButton.SetUnselected();
            }
        }
        CustomizationManager.MaxSelectableWeapons = Hull.NumberOfWeapons;
        
        SelectedUI.SetActive(true);
    }


    private void SetUnselected()
    {
        SelectedUI.SetActive(false);
    }


    public void SelectHull()
    {
        CustomizationManager.DisplayInfo(Hull.Name, Hull.Description);
        SetSelected();
        foreach (HullSelectionButton hullSelectionButton in CustomizationManager.HullSelectionButtons)
        {
            if(hullSelectionButton != this)
            {
                hullSelectionButton.SetUnselected();
            }
        }
    }
}
