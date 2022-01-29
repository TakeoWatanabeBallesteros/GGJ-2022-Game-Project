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
    }

    private void OnDisable()
    {
        ColorManager.OnColorUpdate -= UpdateColor;
    }
    private void Awake() {
        
        _collider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}
