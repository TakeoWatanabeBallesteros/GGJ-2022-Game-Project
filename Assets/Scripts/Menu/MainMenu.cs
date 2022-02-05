using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button MainMenuInitButton;
    [SerializeField]
    Slider OptionsInitButton;
    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void PlayCreditScene()
    {
        SceneManager.LoadScene("Credits");
        
        FindObjectOfType<AudioManager>().Play("Credits");
    }
    public void ExitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void SelectOptionsButton(){
        OptionsInitButton.Select();
    }
    public void SelectMainMenuButton(){ 
        MainMenuInitButton.Select();
    }
}
