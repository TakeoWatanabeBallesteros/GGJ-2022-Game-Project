using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public float MovementHorizontal { get; private set; }
    public float MovementVertical { get; private set; }
    public Action jumpStarted;
    public Action jumpFinished;

    // Update is called once per frame
    void Update()
    {
        MovementHorizontal = Input.GetAxis("Horizontal");
        MovementVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("space")) jumpStarted?.Invoke();
        if (Input.GetKeyUp("space")) jumpFinished?.Invoke();
    }
}
