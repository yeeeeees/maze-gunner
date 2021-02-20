using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject AudioSubmenuUI;
    public GameObject GraphicsSubmenuUI;
    public GameObject ControlsSubemnuUI;
    public GameObject ConfirmationSubmenuUI;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Loading scene index 1");
    }

    public void LevelSelect()
    {
        //Trenutno ne postoji
        Debug.Log("Opening Level Select");
    }

    public void LoadOptions()
    {
        //Trenutno ne postoji
        Debug.Log("Opening options");
    }

    public void LoadCredits()
    {
        //Trenutno ne postiji
        Debug.Log("Opening Credits");
    }

    public void QuitGame()
    {
        //Radi samo kada je buildano
        Application.Quit();
        Debug.Log("Quitting");
    }
    private void CloseAllMenus()
    {
        OptionsMenuUI.SetActive(false);
        AudioSubmenuUI.SetActive(false);
        GraphicsSubmenuUI.SetActive(false);
        ControlsSubemnuUI.SetActive(false);
        ConfirmationSubmenuUI.SetActive(false);
    }
}