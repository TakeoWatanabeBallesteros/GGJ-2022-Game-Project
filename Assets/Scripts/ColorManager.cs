using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private Color[] _Acolors;
    [SerializeField]
    private Color[] _Bcolors;
    private Color[] _currentColors = new Color[2];
    [HideInInspector]
    public Color[] CurrentColors { get { return _currentColors; } }
    int currAColor = 0;
    int currBColor = 0;
    public static Action<Color[]> OnColorUpdate;
    public static Action<Color[]> OnColorSwitch;
    public static Action OnColorSwitched;

    private static ColorManager _instance;
    public static ColorManager Instance => _instance;

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
            Destroy(gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<ColorManager>();
            DontDestroyOnLoad(gameObject);
        }
    }
     private void OnEnable()
    {
        EnergyBall.OnEnergyBallCollected += ChangeColor;
        Controls.Scenario.SwitchColors.Enable();
        Controls.Scenario.SwitchColors.performed += _ =>
        {
            OnColorSwitch?.Invoke(CurrentColors);
            OnColorSwitched?.Invoke();
        };
        //Checkear si peta
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        _currentColors[0] = _Acolors[currAColor];
        _currentColors[1] = _Bcolors[currBColor];
    }

    private void OnDisable()
    {
        Controls.Scenario.SwitchColors.Disable();
        Controls.Scenario.SwitchColors.performed -= _ =>
        {
            OnColorSwitch?.Invoke(CurrentColors);
            OnColorSwitched?.Invoke();
        };
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //OnColorSwitched?.Invoke();
    }

    public void ChangeColor(GameObject obj, bool top)
    {
        if (top) currBColor++;
        else currAColor++;
        _currentColors[0] = _Acolors[currAColor];
        _currentColors[1] = _Bcolors[currBColor];
        OnColorUpdate?.Invoke(CurrentColors);
    }
}
