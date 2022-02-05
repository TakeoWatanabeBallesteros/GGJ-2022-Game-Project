using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageComponentHUD : MonoBehaviour
{  
    [SerializeField]
    Image shiftPC;
    [SerializeField]
    Image shiftMobile;
    public Sprite originalSprite;
    public Sprite pressedSprite;

  
    ColorManager colorManager;

    private static ImageComponentHUD _instance;
    public static ImageComponentHUD Instance => _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<ImageComponentHUD>();
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        GameObject CM = GameObject.FindWithTag("Color Manager");
        colorManager = CM.GetComponent<ColorManager>();
        ColorManager.OnColorSwitch +=()=>
        {
           if(colorManager._SwitchColor){//if true is on
                shiftPC.sprite = pressedSprite;
                shiftMobile.sprite = pressedSprite;
           }else{shiftPC.sprite = originalSprite;
           shiftMobile.sprite = originalSprite;}
        };
    }

    private void OnDisable()
    {
        ColorManager.OnColorSwitch -=()=>
        {
           if(colorManager._SwitchColor){//if true is on
                shiftPC.sprite = pressedSprite;
                shiftMobile.sprite = pressedSprite;
           }else{shiftPC.sprite = originalSprite;
           shiftMobile.sprite = originalSprite;}
        };
    }
    
    private void Start() {
        if(colorManager._SwitchColor){//if true is on
                shiftPC.sprite = pressedSprite;
                shiftMobile.sprite = pressedSprite;
           }else{shiftPC.sprite = originalSprite;
           shiftMobile.sprite = originalSprite;}
    }

 
}
