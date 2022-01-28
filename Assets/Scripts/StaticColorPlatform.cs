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
        print(ColorManager.Instance.currentColors[0] == Color.black);
        ColorManager.Instance.OnColorSwitched += CheckColor;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnColorSwitched -= CheckColor;
    }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = ColorManager.Instance.currentColors[colorIdx];
    }

    public void CheckColor()
    {
       _collider.enabled = _background.myColor != _renderer.color;
    }
}
