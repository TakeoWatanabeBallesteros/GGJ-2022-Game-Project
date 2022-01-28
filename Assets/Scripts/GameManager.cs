using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void Win();
    public static Win OnWin;

    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }

    void OnEnable() {
        Controls.Player.SwtichPlayer.Enable();
        Controls.Player.SwtichPlayer.performed += _ => SwitchPlayer();
    }

    void OnDisable() {
        Controls.Player.SwtichPlayer.Disable();
        Controls.Player.SwtichPlayer.performed -= _ => SwitchPlayer();
    }
    private void Start() {
        SwitchPlayer();
    }
    void SwitchPlayer(){
        if (player1.GetComponent<PlayerMovement>().CanMove){
            player2.GetComponent<PlayerMovement>().EnableMovement();
            player1.GetComponent<PlayerMovement>().DisableMovement();
        }
        else{
            player1.GetComponent<PlayerMovement>().EnableMovement();
            player2.GetComponent<PlayerMovement>().DisableMovement();
        }
    }
}
