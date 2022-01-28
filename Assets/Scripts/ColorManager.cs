using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private Color[] _colors;
    [HideInInspector]
    public Color[] colors { get { return _colors; } }

    private static ColorManager _instance;
    public static ColorManager Instance { get { return _instance; } }

    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    private void OnEnable()
    {
        Controls.Scenario.SwitchColors.Enable();
        Controls.Scenario.SwitchColors.performed += _ => ChangeColors();
    }

    private void OnDisable()
    {
        Controls.Scenario.SwitchColors.Disable();
        Controls.Scenario.SwitchColors.performed -= _ => ChangeColors();
    }

    private void ChangeColors()
    {
        foreach(ColorBackground bkgd in GameObject.FindObjectsOfType<ColorBackground>())
        {
            bkgd.ChangeColor();
        }
        foreach (StaticColorPlatform platform in GameObject.FindObjectsOfType<StaticColorPlatform>())
        {
            platform.CheckColor();
        }
        foreach (ChangingColorPlatform platform in GameObject.FindObjectsOfType<ChangingColorPlatform>())
        {
            platform.CheckColor();
        }
    }
}
