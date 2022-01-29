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
    }

    private void OnDisable()
    {
        ColorManager.OnColorUpdate -= UpdateColor;
        ColorManager.OnColorSwitch -= SwitchColor;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider2D>();
    }
}
