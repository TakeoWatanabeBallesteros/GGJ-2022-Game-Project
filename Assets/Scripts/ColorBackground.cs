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
        ColorManager.OnColorUpdate += UpdateColor;
    }

    private void OnDisable()
    {
        ColorManager.OnColorUpdate -= UpdateColor;
    }
    private void Awake() {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _renderer.color = ColorManager.Instance.CurrentColors[colorIdx];
    }

    protected void UpdateColor(Color[] colorArray)
    {
        _renderer.color = colorArray[colorIdx];
    }
}
