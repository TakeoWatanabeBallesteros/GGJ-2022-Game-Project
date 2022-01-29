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

    public bool _SwitchColor  { get { return SwitchColor; } }
    bool SwitchColor = false;

    public static Action<Color[]> OnColorUpdate;
    public static Action OnColorSwitched;
    public static Action OnColorSwitch;

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
            SwitchColor = !SwitchColor;
            OnColorSwitch?.Invoke();
            SetColors();
            OnColorSwitched?.Invoke();
        };
        //Checkear si peta
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(SwitchColor){//Top = B / Bot = A
            _currentColors[1] = _Acolors[currAColor];
            _currentColors[0] = _Bcolors[currBColor];
        }
        else{//Bottom = B / Bot = A
            _currentColors[0] = _Acolors[currAColor];
            _currentColors[1] = _Bcolors[currBColor];
        }
    }

    private void OnDisable()
    {
        EnergyBall.OnEnergyBallCollected -= ChangeColor;
        Controls.Scenario.SwitchColors.Disable();
        Controls.Scenario.SwitchColors.performed -= _ =>
        {
            SwitchColor = !SwitchColor;
            OnColorSwitch?.Invoke();
            SetColors();
            OnColorSwitched?.Invoke();
        };
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if(SwitchColor){//Top = B / Bot = A
            _currentColors[1] = _Acolors[currAColor];
            _currentColors[0] = _Bcolors[currBColor];
        }
        else{//Bottom = B / Bot = A
            _currentColors[0] = _Acolors[currAColor];
            _currentColors[1] = _Bcolors[currBColor];
        }
    }
   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SwitchColor) OnColorSwitch?.Invoke();
        SetColors();
        OnColorSwitched?.Invoke();
    }

    void SetColors(){ 
        if(SwitchColor){//Top = B / Bot = A
            _currentColors[1] = _Acolors[currAColor];
            _currentColors[0] = _Bcolors[currBColor];
        }
        else{//Bottom = B / Bot = A
            _currentColors[0] = _Acolors[currAColor];
            _currentColors[1] = _Bcolors[currBColor];
        }
        OnColorUpdate?.Invoke(CurrentColors);
    }

    public void ChangeColor(GameObject obj, bool top, float phisicInceaseFactor)
    {
        if (top) currBColor++;
        else currAColor++;
        SetColors();
    }
}
