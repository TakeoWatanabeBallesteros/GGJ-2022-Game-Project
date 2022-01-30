using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void SoundClickClickMeCagoEnLaPutaMadre(){
        FindObjectOfType<AudioManager>().Play("ON"+UnityEngine.Random.Range(1,4).ToString());
    }
}
