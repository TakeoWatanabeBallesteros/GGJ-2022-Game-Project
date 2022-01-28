using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBackground : MonoBehaviour
{
    ColorManager Instance;
    public Color myColor => _renderer.color;
    protected SpriteRenderer _renderer;
    [SerializeField]
    protected int colorIdx;

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
    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected void UpdateColor(Color[] colorArray)
    {
        _renderer.color = colorArray[colorIdx];
    }

    public void SwitchColor(Color[] colorArray)
    {
        colorIdx = (colorIdx + 1) % 2;
        _renderer.color = colorArray[colorIdx];
    }
}
