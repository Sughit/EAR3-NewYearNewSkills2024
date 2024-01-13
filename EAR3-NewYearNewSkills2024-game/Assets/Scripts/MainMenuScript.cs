using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main, settings;
    public GameObject inGameMenu;

    void InGameMenu()
    {   
        if(inGameMenu != null)
        {
            if(inGameMenu.activeSelf) inGameMenu.SetActive(false);
            else inGameMenu.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) InGameMenu();
    }

    public void PlayGame()
    {
         SceneManager.LoadScene("Main");
    }
    public void Settings()
    {
        settings.SetActive(true);
        main.SetActive(false);
    }
    public void BackSettings()
    {
        main.SetActive(true);
        settings.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
