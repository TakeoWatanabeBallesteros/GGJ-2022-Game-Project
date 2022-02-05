using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickPosition : MonoBehaviour
{
    [SerializeField]
    Image Joystick;
    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }
    private void Awake() {
        Joystick = gameObject.GetComponent<Image>();
        Joystick.enabled = false;
    }
    private void OnEnable() {
        Controls.Touch.TouchPress.Enable();
        Controls.Touch.TouchPos.Enable();
        Controls.Touch.TouchPress.performed += _ => SetJoystick();
        Controls.Touch.TouchPress.canceled += _ => {Joystick.enabled = false;};
    }
    private void OnDisable() {
        Controls.Touch.TouchPress.Disable();
        Controls.Touch.TouchPos.Disable();
        Controls.Touch.TouchPress.performed -= _ => SetJoystick();
        Controls.Touch.TouchPress.canceled -= _ => {Joystick.enabled = false;};
    }

    void SetJoystick(){
        Joystick.enabled = true;
        Controls.Touch.TouchPos.performed += ctx => {
            Vector2 touchPos = ctx.ReadValue<Vector2>();
            if(touchPos.x < Screen.width/2 && touchPos.y > Screen.height/2)
                transform.position = touchPos;};
    }
}
