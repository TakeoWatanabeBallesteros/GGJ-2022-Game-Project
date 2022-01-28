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
        ColorManager.Instance.OnColorUpdate += UpdateColor;
        ColorManager.Instance.OnColorSwitch += SwitchColor;
    }

    private void OnDisable()
    {
        ColorManager.Instance.OnColorUpdate -= UpdateColor;
        ColorManager.Instance.OnColorSwitch -= SwitchColor;
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
