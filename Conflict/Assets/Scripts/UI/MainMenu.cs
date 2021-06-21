using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MapSelection;
    public GameObject ControlsImage;
    public void OpenMapSelection()
    {
        MapSelection.SetActive(true);
        ControlsImage.SetActive(false);
    }

    public void ToggleControls()
    {
        ControlsImage.SetActive(!ControlsImage.activeSelf);
        MapSelection.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGrasslandMap()
    {
        SceneManager.LoadScene("Map1");
    }

    public void LoadDesertMap()
    {
        SceneManager.LoadScene("Map2");
    }
}
