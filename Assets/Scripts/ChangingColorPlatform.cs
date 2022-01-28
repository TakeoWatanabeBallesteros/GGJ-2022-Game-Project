using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColorPlatform : ColorBackground
{
    [SerializeField]
    ColorBackground _background;
    Collider2D _collider;

    // Start is called before the first frame update
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
