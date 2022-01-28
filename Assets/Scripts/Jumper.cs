using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    //Altres classes
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private GroundChecker _groundChecker;
    //[SerializeField]
    //private GroundChecker _wallChecker;
    private PlayerInput _input;

    //Parametres del salt
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float timeToPeak;
    DateTime timeStart;
    //Parametres de la gravetat
    int gravityDir;
    [SerializeField]
    float gravityConstant;

    //flags i controladors
    float lastVelocityFrame;
    public bool imJumping;
    public bool peakReached;
    bool onGravityArea;
    //bool onHorizontalGravityArea;

    private void OnDrawGizmos()
    {
        float y = transform.position.y + jumpHeight;
        Vector3 start = new Vector3(transform.position.x - 1, y, 0);
        Vector3 end = new Vector3(transform.position.x + 1, y, 0);
        Gizmos.DrawLine(start, end);
    }

    void Awake()
    {
        onGravityArea = false;
        //onHorizontalGravityArea = false;
        peakReached = false;
        imJumping = false;
        gravityDir = 1;
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (imJumping && (Math.Sign(lastVelocityFrame) > 0) && (Math.Sign(_rigidbody.velocity.y) < 0) && peakReached == false)
        {
            if (onGravityArea == true)
            {
                gravityDir = -gravityDir;
                _rigidbody.gravityScale = gravityDir;
                transform.Rotate(new Vector3(0, 180, 180));
                peakReached = true;
            }
        }
        lastVelocityFrame = _rigidbody.velocity.y * gravityDir;
    }

    private void OnEnable()
    {
        _groundChecker.OnLanded += OnLanded;
        //_wallChecker.OnLanded += OnWall;
        //_wallChecker.LeftLand += LeftWall;
        _input.jumpStarted += OnJumpStarted;
        _input.jumpFinished += OnJumpFinished;
    }

    private void OnDisable()
    {
        _groundChecker.OnLanded -= OnLanded;
        //_wallChecker.OnLanded -= OnWall;
        //_wallChecker.OnLanded -= LeftWall;
        _input.jumpStarted -= OnJumpStarted;
        _input.jumpFinished -= OnJumpFinished;
    }

    private void OnLanded()
    {
        imJumping = false;
        peakReached = false;
        _rigidbody.gravityScale = gravityDir;
    }

    //private void OnWall()
    //{
    //    imJumping = false;
    //    peakReached = false;
    //    _forceController.SetVerticalVelocity(0);
    //    _rigidbody.gravityScale = 0.1f * _forceController.GetGravityDir();
    //}
    //
    //private void LeftWall()
    //{
    //    _rigidbody.gravityScale = _forceController.GetGravityDir();
    //}

    public void setJump()
    {
        jumpHeight *= 2;
    }

    void OnJumpStarted()
    {
        if (CanJump())
        {
            timeStart = DateTime.Now;
            Jump();
        }
    }

    private void OnJumpFinished()
    {
        if (imJumping)
        {
            TimeSpan secondsPassed = DateTime.Now - timeStart;
            _rigidbody.gravityScale += Mathf.Clamp(1 - ((float)secondsPassed.TotalSeconds / timeToPeak), 0, 1) * gravityConstant * gravityDir;
        }
    }

    void Jump()
    {
        imJumping = true;

        //if (_wallChecker.isGrounded && !_groundChecker.isGrounded)
        //{
        //    _rigidbody.gravityScale = gravityDir;
        //}
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, GetVelocity());
        SetGravity();
    }

    float GetVelocity()
    {
        return 2 * jumpHeight / timeToPeak * gravityDir;
    }

    bool CanJump()
    {
        return _groundChecker.isGrounded; // || _wallChecker.isGrounded;
    }

    void SetGravity()
    {
        _rigidbody.gravityScale = gravityDir * (-2 * jumpHeight / (timeToPeak * timeToPeak)) / Physics2D.gravity.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gravityArea"))
        {
            onGravityArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gravityArea"))
        {
            onGravityArea = false;
        }
    }
}
