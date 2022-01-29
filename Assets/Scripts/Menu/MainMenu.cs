using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Scene Game");
        SceneManager.LoadScene(1);
    }

    public void PlayCreditScene()
    {
        Debug.Log("Scene CREDITS");
        SceneManager.LoadScene(2);
        
        FindObjectOfType<AudioManager>().Play("Credits");
    }
    public void ExitGame()
    {
        #if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        Debug.Log("Quit");
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

       
    }
}
