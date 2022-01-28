using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingColorPlatform : ColorBackground
{
    [SerializeField]
    ColorBackground _background;
    Collider2D _collider;

    private void OnEnable()
    {
        ColorManager.Instance.OnColorUpdate += UpdateColor;
        ColorManager.Instance.OnColorSwitch += SwitchColor;
        ColorManager.Instance.OnColorSwitched += CheckColor;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnColorUpdate -= UpdateColor;
        ColorManager.Instance.OnColorSwitch -= SwitchColor;
        ColorManager.Instance.OnColorSwitched -= CheckColor;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider2D>();
    }

    public void CheckColor()
    {
        _collider.enabled = _background.myColor != _renderer.color;
    }
}
