using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColorPlatform : MonoBehaviour
{
    [SerializeField]
    ColorBackground _background;
    SpriteRenderer _renderer;
    Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void CheckColor()
    {
       _collider.enabled = _background.myColor != _renderer.color;
    }
}
