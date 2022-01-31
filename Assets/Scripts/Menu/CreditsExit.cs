using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsExit : MonoBehaviour
{
    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }
    void OnEnable() {
        Controls.Player.Pause.Enable();
        Controls.Player.Pause.performed += _ => {SceneManager.LoadScene("Menu");};
    }

    void OnDisable() {
        Controls.Player.Pause.Disable();
        Controls.Player.Pause.performed -= _ => {SceneManager.LoadScene("Menu");};
    }
}
