using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBackground : MonoBehaviour
{
    public Color[] colors;
    public Color myColor => _renderer.color;
    Color t;
    protected SpriteRenderer _renderer;
    int colorIdx;
    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        colorIdx = 0;
        _renderer.color = colors[colorIdx];
    }

    public void ChangeColor()
    {
        colorIdx = (colorIdx + 1) % colors.Length;
        _renderer.color = colors[colorIdx];
    }
}
