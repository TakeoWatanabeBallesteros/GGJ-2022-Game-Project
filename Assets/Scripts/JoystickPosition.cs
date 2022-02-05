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
        //Joystick.enabled = false;
    }
    private void OnEnable() {
        Controls.Scenario.MousePos.Enable();
        Controls.Scenario.MousePos.performed += ctx => {transform.position = new Vector3(ctx.ReadValue<Vector2>().x,ctx.ReadValue<Vector2>().y, 0);};
        //Controls.Touch.TouchPress.Enable();
        Controls.Touch.TouchPos.Enable();
        Controls.Touch.TouchPress.performed += _ => {Joystick.enabled = true;};
        Controls.Touch.TouchPress.canceled += _ => {Joystick.enabled = false;};
        Controls.Touch.TouchPos.performed += ctx => {transform.position = new Vector3(ctx.ReadValue<Vector2>().x,ctx.ReadValue<Vector2>().y, 0);};
    }
    private void OnDisable() {
        Controls.Touch.TouchPress.Disable();
        Controls.Touch.TouchPos.Disable();
        Controls.Touch.TouchPress.performed -= _ => {Joystick.enabled = true;};
        Controls.Touch.TouchPress.canceled -= _ => {Joystick.enabled = false;};
        Controls.Touch.TouchPos.performed -= ctx => {transform.position = new Vector3(ctx.ReadValue<Vector2>().x,ctx.ReadValue<Vector2>().y, 0);};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
