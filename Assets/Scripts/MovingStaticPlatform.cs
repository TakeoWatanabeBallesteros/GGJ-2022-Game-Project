using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStaticPlatform : StaticColorPlatform
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("background"))
        {
            _background = collision.GetComponent<ColorChanginElement>();
        }
    }

}
