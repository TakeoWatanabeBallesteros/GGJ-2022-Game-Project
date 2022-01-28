using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColorPlatform : ColorBackground
{
    [SerializeField]
    ColorBackground _background;
    Collider2D _collider;

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
