using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private Color[] _Acolors;
    [SerializeField]
    private Color[] _Bcolors;
    private Color[] _currentColors;
    [HideInInspector]
    public Color[] currentColors { get { return _currentColors; } }
    int currAColor;
    int currBColor;
    public Action<Color[]> OnColorUpdate;
    public Action<Color[]> OnColorSwitch;
    public Action OnColorSwitched;

    private static ColorManager _instance;
    public static ColorManager Instance { get { return _instance; } } 

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
        EnergyBall.OnEnergyBallCollected += ChangeColor;
        Controls.Scenario.SwitchColors.Enable();
        Controls.Scenario.SwitchColors.performed += _ =>
        {
            OnColorSwitch?.Invoke(currentColors);
            OnColorSwitched?.Invoke();
        };
        //Checkear si peta
    }

    private void OnDisable()
    {
        Controls.Scenario.SwitchColors.Disable();
        Controls.Scenario.SwitchColors.performed -= _ => OnColorSwitch?.Invoke(currentColors);
    }

    public void ChangeColor(GameObject ob, bool top)
    {
        if (top) currAColor++;
        else currBColor++;
        _currentColors[0] = _Acolors[currAColor];
        _currentColors[1] = _Bcolors[currBColor];
        OnColorUpdate?.Invoke(currentColors);
    }
}
