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
    public GameObject CreditsSubmenuUI;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Loading scene index 1");
    }

    public void QuitGame()
    {
        //Works only when built
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
        CreditsSubmenuUI.SetActive(false);
    }
}