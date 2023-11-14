using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settingsMenu;
    public PostProcessingManager ppm;

    public void Play()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void BluePill()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void RedPill()
    {
        SceneManager.LoadScene("Main Game");
    }
}
