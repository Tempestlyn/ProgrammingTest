using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    public TankCustomization CustomizationManager;
    public Sprite TankSprite;
    public GameObject SelectedUI;
    public bool DefaultSelection;

    private void Start()
    {
        if (DefaultSelection)
        {
            SelectColor();
        }
    }

    private void SetSelected()
    {
        CustomizationManager.SelectedSprite = TankSprite;
        SelectedUI.SetActive(true);
    }

    private void SetUnselected()
    {
        SelectedUI.SetActive(false);
    }

    public void SelectColor()
    {
        SetSelected();
        foreach (ColorSelection colorSelection in CustomizationManager.ColorSelectionButtons)
        {
            if (colorSelection != this)
            {
                colorSelection.SetUnselected();
            }
        }
    }
}