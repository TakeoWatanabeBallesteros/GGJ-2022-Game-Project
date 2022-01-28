using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColorPlatform : ColorBackground
{
    [SerializeField]
    ColorBackground _background;
    Collider2D _collider;

    private void OnEnable()
    {
        ColorManager.OnColorUpdate += UpdateColor;
        ColorManager.OnColorSwitch += SwitchColor;
        ColorManager.OnColorSwitched += CheckColor;
    }

    private void OnDisable()
    {
        ColorManager.OnColorUpdate -= UpdateColor;
        ColorManager.OnColorSwitch -= SwitchColor;
        ColorManager.OnColorSwitched -= CheckColor;
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
