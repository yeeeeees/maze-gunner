using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 
    public bool IsGamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject AudioSubmenuUI;
    public GameObject GraphicsSubmenuUI;
    public GameObject ControlsSubmenuUI;
    public GameObject ConfirmationSubenuUI;

    void start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (IsGamePaused)
                Resume();
            else
                Pause();
        }
    }

    //Cursor settings don't work properly in-engine, you must buld the project
    public void Resume()
    {
        CloseAllMenus();
        Time.timeScale = 1f;
        IsGamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Resuming");
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Pausing Game");
    }

    public void Restart()
    {
        PauseMenuUI.SetActive(false);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        Debug.Log("Restarting");
    }

    public void LoadMainMenu()
    { 
        //Loads the first scene (0)
        //Make sure you set the main menu scene as scene o in build index settings
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Destroy(this.gameObject);
        Debug.Log("Loading Main Menu");
    }

    public void QuitGame()
    {
        //Aplication qit works only when project is built
        Application.Quit();
        Debug.Log("Quitting");
    }

    private void CloseAllMenus()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        AudioSubmenuUI.SetActive(false);
        GraphicsSubmenuUI.SetActive(false);
        ControlsSubmenuUI.SetActive(false);
        ConfirmationSubenuUI.SetActive(false);
    }
}