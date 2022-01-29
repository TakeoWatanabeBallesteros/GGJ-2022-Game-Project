using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageComponentHUD : MonoBehaviour
{
    Image myImageComponent; // Image component attached to this gameobject

    public Sprite originalSprite;
    public Sprite pressedSprite;


    void Start() 
    {
        myImageComponent = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myImageComponent.sprite = pressedSprite;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            myImageComponent.sprite = originalSprite;
        }
    }
}
