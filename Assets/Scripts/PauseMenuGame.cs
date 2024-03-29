using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuGame : MonoBehaviour
{

    [SerializeField]
    Button PauseInitButton;
    public GameObject pauseMenuUI;

    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }

    void OnEnable() {
        Controls.Player.Pause.Enable();
        Controls.Player.Pause.performed += _ => {(pauseMenuUI.activeSelf ? new Action(Resume) : new Action(Pause))();
        PauseInitButton.Select();};
    }

    void OnDisable() {
        Controls.Player.Pause.Disable();
        Controls.Player.Pause.performed -= _ => {(pauseMenuUI.activeSelf ? new Action(Resume) : new Action(Pause))();
        PauseInitButton.Select();};
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public  void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //public void QuitGame()
    //{
    //    Application.Quit();
    //}
}
