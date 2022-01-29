using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColorPlatform : MonoBehaviour
{
    [SerializeField]
    int colorIdx;
    [SerializeField]
    protected ColorChanginElement _background;
    SpriteRenderer _renderer;
    Collider2D _collider;

    private void OnEnable()
    {
        ColorManager.OnColorSwitch += SwitchColor;
        ColorManager.OnColorSwitched += CheckColor;
        ColorManager.OnColorUpdate += UpdateColor;
    }

    private void OnDisable()
    {
        ColorManager.OnColorSwitch -= SwitchColor;
        ColorManager.OnColorSwitched -= CheckColor;
        ColorManager.OnColorUpdate -= UpdateColor;

    }

    private void Awake() {
        
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _renderer.color = ColorManager.Instance.CurrentColors[colorIdx];
    }

    void UpdateColor(Color[] colorArray)
    {
        _renderer.color = colorArray[colorIdx];
    }
    void SwitchColor()
    {
        colorIdx = (colorIdx + 1) % 2;
    }

    void CheckColor()
    {
       _collider.enabled = _background.myColor != _renderer.color;
    }
}
