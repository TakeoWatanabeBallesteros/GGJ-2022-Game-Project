using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMenu : MonoBehaviour
{
    Vector2 mousePosition;
    [SerializeField] float movementQuantity;

    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    private void OnEnable()
    {
        Controls.Scenario.MousePos.Enable();
        Controls.Scenario.MousePos.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        Controls.Scenario.MousePos.Disable();
        Controls.Scenario.MousePos.performed -= ctx => mousePosition = ctx.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().position = new Vector2((mousePosition.x / Screen.width) * movementQuantity + (Screen.width / 2), (mousePosition.y / Screen.height) * movementQuantity + (Screen.height / 2));
    }
}
