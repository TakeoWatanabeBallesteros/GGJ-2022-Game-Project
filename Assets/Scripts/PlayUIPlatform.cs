using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject restart;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject movePhone;
    [SerializeField]
    GameObject jumpPhone;
    [SerializeField]
    GameObject shiftPhone;
    [SerializeField]
    GameObject shiftPC;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
            restart.SetActive(true);
            pause.SetActive(true);
            movePhone.SetActive(true);
            jumpPhone.SetActive(true);
            shiftPhone.SetActive(true);
            shiftPC.SetActive(false);
        }else{
            restart.SetActive(false);
            pause.SetActive(false);
            movePhone.SetActive(false);
            jumpPhone.SetActive(false);
            shiftPhone.SetActive(false);
            shiftPC.SetActive(true);
        }
    }
}