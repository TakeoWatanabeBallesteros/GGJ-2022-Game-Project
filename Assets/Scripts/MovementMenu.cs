﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMenu : MonoBehaviour
{
    float mousePosX;
    float mousePosY;
    [SerializeField] float movementQuantity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2((mousePosX / Screen.width) * movementQuantity + (Screen.width / 2), (mousePosY / Screen.height) * movementQuantity + (Screen.height / 2));
    }
}
