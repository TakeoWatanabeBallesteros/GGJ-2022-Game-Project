using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBackground : MonoBehaviour
{
    public Color myColor => _renderer.color;
    protected SpriteRenderer _renderer;
    [SerializeField]
    protected int colorIdx;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = ColorManager.Instance.colors[colorIdx];
    }

    public void ChangeColor()
    {
        colorIdx = (colorIdx + 1) % 2;
        _renderer.color = ColorManager.Instance.colors[colorIdx];
    }
}
