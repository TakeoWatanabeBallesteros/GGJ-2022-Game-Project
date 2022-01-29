using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageComponentHUD : MonoBehaviour
{
    Image myImageComponent; // Image component attached to this gameobject

    public Sprite originalSprite;
    public Sprite pressedSprite;

    ColorManager colorManager;

    private static ImageComponentHUD _instance;
    public static ImageComponentHUD Instance => _instance;

    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }

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
        Controls.Scenario.SwitchColors.Enable();
        Controls.Scenario.SwitchColors.performed += _ =>
        {
           if(colorManager._SwitchColor){//if true is on
                myImageComponent.sprite = pressedSprite;
           }else{myImageComponent.sprite = originalSprite;}
        };
    }

    private void OnDisable()
    {
        Controls.Scenario.SwitchColors.Disable();
        Controls.Scenario.SwitchColors.performed -= _ =>
        {
            
        };
    }
    void Start() 
    {
        myImageComponent = GetComponent<Image>();
    }
    
}
