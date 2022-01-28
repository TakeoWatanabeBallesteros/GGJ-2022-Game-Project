using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    //Altres classes
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private GroundChecker _groundChecker;
    [SerializeField]
    private GroundChecker _wallChecker;
    private PlayerInput _input;
    private ForceController _forceController;

    //Parametres del salt
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float timeToPeak;
    DateTime timeStart;
    //Parametres de la gravetat
    [SerializeField]
    float gravityConstant;

    //flags i controladors
    float lastVelocityFrame;
    public bool imJumping;
    public bool peakReached;
    bool onGravityArea;
    bool onHorizontalGravityArea;

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
        onHorizontalGravityArea = false;
        peakReached = false;
        imJumping = false;
        _forceController = GetComponent<ForceController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (imJumping && (Math.Sign(lastVelocityFrame) > 0) && (Math.Sign(_forceController.GetVerticalVelocity() * _forceController.GetGravityDir()) < 0) && peakReached == false)
        {
            if (onGravityArea == true)
            {
                _forceController.InvertGravityDir();
                _rigidbody.gravityScale = _forceController.GetGravityDir();
                transform.Rotate(new Vector3(0, 180, 180));
                peakReached = true;
            }
            else if (onHorizontalGravityArea == true)
            {
                peakReached = true;
                if (_forceController.CheckVerticalGravity())
                {
                    transform.Rotate(new Vector3(180, 0, 90));
                    peakReached = true;
                    _forceController.ChangeGravityDir();
                    Physics2D.gravity = new Vector2(-9.81f, 0);
                }
                else
                {
                    transform.Rotate(new Vector3(180, 0, -90));
                    peakReached = true;
                    _forceController.ChangeGravityDir();
                    Physics2D.gravity = new Vector2(0, -9.81f);
                }
            }
        }
        lastVelocityFrame = _forceController.GetVerticalVelocity() * _forceController.GetGravityDir();
    }

    private void OnEnable()
    {
        _groundChecker.OnLanded += OnLanded;
        _wallChecker.OnLanded += OnWall;
        _wallChecker.LeftLand += LeftWall;
        _input.jumpStarted += OnJumpStarted;
        _input.jumpFinished += OnJumpFinished;
    }

    private void OnDisable()
    {
        _groundChecker.OnLanded -= OnLanded;
        _wallChecker.OnLanded -= OnWall;
        _wallChecker.OnLanded -= LeftWall;
        _input.jumpStarted -= OnJumpStarted;
        _input.jumpFinished -= OnJumpFinished;
    }

    private void OnLanded()
    {
        imJumping = false;
        peakReached = false;
        _rigidbody.gravityScale = _forceController.GetGravityDir();
    }

    private void OnWall()
    {
        imJumping = false;
        peakReached = false;
        _forceController.SetVerticalVelocity(0);
        _rigidbody.gravityScale = 0.1f * _forceController.GetGravityDir();
    }

    private void LeftWall()
    {
        _rigidbody.gravityScale = _forceController.GetGravityDir();
    }

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
            _rigidbody.gravityScale += Mathf.Clamp(1 - ((float)secondsPassed.TotalSeconds / timeToPeak), 0, 1) * gravityConstant * _forceController.GetGravityDir();
        }
    }

    void Jump()
    {
        imJumping = true;

        if (_wallChecker.isGrounded && !_groundChecker.isGrounded)
        {
            _rigidbody.gravityScale = _forceController.GetGravityDir();
        }
        _forceController.SetVerticalVelocity(GetVelocity());
        SetGravity();
    }

    float GetVelocity()
    {
        return 2 * jumpHeight / timeToPeak * _forceController.GetGravityDir();
    }

    bool CanJump()
    {
        return _groundChecker.isGrounded || _wallChecker.isGrounded;
    }

    void SetGravity()
    {
        _rigidbody.gravityScale = _forceController.GetGravityDir() * (-2 * jumpHeight / (timeToPeak * timeToPeak)) / (Physics2D.gravity.y + Physics2D.gravity.x);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gravityArea"))
        {
            onGravityArea = true;
        }

        if (other.CompareTag("gravityAreaHoritzontal"))
        {
            onHorizontalGravityArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("gravityArea"))
        {
            onGravityArea = false;
        }

        if (other.CompareTag("gravityAreaHoritzontal"))
        {
            onHorizontalGravityArea = false;
        }
    }
}
