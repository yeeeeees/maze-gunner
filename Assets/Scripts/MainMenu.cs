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

    void Start()
    {
        DestoryObjetsOnMainMenuLoad();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAllMenusMain();
        }
    }

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

    private void DestoryObjetsOnMainMenuLoad()
    {
        //Add here objects you want destoryed when the main menu loads
        //Reeber to tag properly in editor
        Destroy (GameObject.FindWithTag("Player"));
        Destroy (GameObject.FindWithTag("PauseMenu"));
    }
    private void CloseAllMenusMain()
    {
        MainMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
        AudioSubmenuUI.SetActive(false);
        GraphicsSubmenuUI.SetActive(false);
        ControlsSubemnuUI.SetActive(false);
        ConfirmationSubmenuUI.SetActive(false);
        CreditsSubmenuUI.SetActive(false);
    }
}