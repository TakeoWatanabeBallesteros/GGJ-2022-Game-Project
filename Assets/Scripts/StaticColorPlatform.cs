using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColorPlatform : MonoBehaviour
{
    [SerializeField]
    int colorIdx;
    [SerializeField]
    ColorBackground _background;
    SpriteRenderer _renderer;
    Collider2D _collider;

    private void OnEnable()
    {
        ColorManager.OnColorSwitched += CheckColor;
        ColorManager.OnColorUpdate += UpdateColor;
    }

    private void OnDisable()
    {
        ColorManager.OnColorSwitched -= CheckColor;
        ColorManager.OnColorUpdate -= UpdateColor;
    }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = ColorManager.Instance.CurrentColors[colorIdx];
    }

    void UpdateColor(Color[] colorArray)
    {
        _renderer.color = colorArray[colorIdx];
    }

    void CheckColor()
    {
       _collider.enabled = _background.myColor != _renderer.color;
    }
}
