using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void Win();
    public static Win OnWin;

    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    static int ballsCollected;

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<GameManager>();
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable() {
        //Controls.Player.SwtichPlayer.Enable();
        Controls.Player.RestartLevel.Enable();
        Controls.Player.RestartLevel.performed += _ => {Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);};
        Controls.Player.SwtichPlayer.performed += _ => SwitchPlayer();
        EnergyBall.OnEnergyBallCollected += BallsCollected;
    }

    void OnDisable() {
        Controls.Player.SwtichPlayer.Disable();
        Controls.Player.RestartLevel.Disable();
        Controls.Player.RestartLevel.performed += _ => {Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);};
        Controls.Player.SwtichPlayer.performed -= _ => SwitchPlayer();
        EnergyBall.OnEnergyBallCollected -= BallsCollected;
    }
    private void Start() {
        //SwitchPlayer();
    }

    void BallsCollected(GameObject obj, bool IsTop, float incr){ 
        ballsCollected++;
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
