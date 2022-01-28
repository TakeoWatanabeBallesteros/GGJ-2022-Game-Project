using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker
{
    [SerializeField]
    Transform GroundCheckTransform;
    [SerializeField]
    Transform RoofCheckTransform;
    [SerializeField]
    float Radius;
    [SerializeField]
    LayerMask WhatIsGround;

    public bool isGrounded => _isGrounded;
    bool _isGrounded;

    private bool _wasGround;
    public Action OnLanded;
    public Action LeftLand;

    void FixedUpdate()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheckTransform.position, Radius, WhatIsGround);
        Collider2D[] roofColliders = Physics2D.OverlapCircleAll(RoofCheckTransform.position, Radius, WhatIsGround);
        _isGrounded = colliders.Length + roofColliders.Length > 0;

        if (!_wasGround && _isGrounded)
        {
            JustLanded();
        }
        else if (_wasGround && !_isGrounded)
        {
            JustLeft();
        }

        _wasGround = _isGrounded;
    }
    void JustLeft()
    {
        LeftLand?.Invoke();
    }
    void JustLanded()
    {
        OnLanded?.Invoke();
    }
}