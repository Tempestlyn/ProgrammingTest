using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadSelection : MonoBehaviour
{
    public TankCustomization CustomizationManager;
    public TankTread Tread;
    public GameObject SelectedUI;
    public bool DefaultSelection;

    private void Start()
    {
        if (DefaultSelection)
        {
            SelectTread();
        }
    }

    private void SetSelected()
    {
        CustomizationManager.SelectedTread = Tread;
        SelectedUI.SetActive(true);
    }

    private void SetUnselected()
    {
        SelectedUI.SetActive(false);
    }

    public void SelectTread()
    {
        CustomizationManager.DisplayInfo(Tread.Name, Tread.Description);
        SetSelected();
        foreach (TreadSelection treadSelection in CustomizationManager.TreadSelectionButtons)
        {
            if (treadSelection != this)
            {
                treadSelection.SetUnselected();
            }
        }
    }
}