using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    //Altres classes
    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;

    //Parametres del salt
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float timeToPeak;
    DateTime timeStart;
    //Parametres de la gravetat
    [SerializeField]
    int gravityDir;
    [SerializeField]
    float gravityEffector;

    //flags i controladors
    float lastVelocityFrame;
    public bool imJumping;
    public bool peakReached;
    bool onGravityArea;

    public Action onJump;
    public Action onPeak;

    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }
    
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
        peakReached = false;
        imJumping = false;
        //gravityDir = 1;
        _groundChecker = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = gravityDir;
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
            }
            peakReached = true;
            onPeak?.Invoke();
        }
        lastVelocityFrame = _rigidbody.velocity.y * gravityDir;
    }

    private void OnEnable()
    {
        _groundChecker.OnLanded += OnLanded;
        Controls.Player.JumpStarted.Enable();
        Controls.Player.JumpStarted.performed += ctx => OnJumpStarted();
        Controls.Player.JumpStarted.canceled += ctx => OnJumpFinished();
        EnergyBall.OnEnergyBallCollected += _EnergyBall;
    }

    private void OnDisable()
    {
        _groundChecker.OnLanded -= OnLanded;
        Controls.Player.JumpStarted.Disable();
        Controls.Player.JumpStarted.performed -= ctx => OnJumpStarted();
        Controls.Player.JumpStarted.canceled -= ctx => OnJumpFinished();
        EnergyBall.OnEnergyBallCollected -= _EnergyBall;
    }

    private void OnLanded()
    {
        imJumping = false;
        peakReached = false;
        _rigidbody.gravityScale = gravityDir;
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
            onJump?.Invoke();
        }
    }

    private void OnJumpFinished()
    {
        if (imJumping)
        {
            TimeSpan secondsPassed = DateTime.Now - timeStart;
            _rigidbody.gravityScale += Mathf.Clamp(1 - ((float)secondsPassed.TotalSeconds / timeToPeak), 0, 1) * gravityEffector * gravityDir;
        }
    }

    void Jump()
    {
        imJumping = true;

        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, GetVelocity());
        SetGravity();
    }

    float GetVelocity()
    {
        return 2 * jumpHeight / timeToPeak * gravityDir;
    }

    bool CanJump()
    {
        return _groundChecker.isGrounded&&GetComponent<PlayerMovement>().CanMove;
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

    private void _EnergyBall(GameObject obj, bool isTop){ 
        if (obj != gameObject){
            //Change param
        }
    }
}
