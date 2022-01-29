using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimations : MonoBehaviour
{
    Jumper jump;
    Rigidbody2D rb;

    public Animator animator;

    GroundChecker groundCheck;

    PlayerMovement playerMove;

    private Controls controls;
    private Controls Controls
    {
        get
        {
            if (controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    bool dreta;

    private void Awake()
    {
        dreta = true;
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jumper>();
        playerMove = GetComponent<PlayerMovement>();
        groundCheck = GetComponent<GroundChecker>();
    }

    private void OnEnable()
    {
        Controls.Player.Move.Enable();
        Controls.Player.Move.performed += ctx=> Speed(ctx.ReadValue<Vector2>());
        jump.onJump += Jump;
        groundCheck.OnLanded += JumpEnded;
        jump.onPeak += Falling;
    }

    private void OnDisable()
    {
        Controls.Player.Move.Disable();
        Controls.Player.Move.performed -= ctx => Speed(ctx.ReadValue<Vector2>());
        jump.onJump -= Jump;
        groundCheck.OnLanded -= JumpEnded;
        jump.onPeak -= Falling;
    }

    public void Speed(Vector2 vector)
    {
        print(vector.x);
        animator.SetFloat("speed", Math.Abs(vector.x));

        if ((dreta && vector.x < 0) || (!dreta && vector.x > 0))
        {
             transform.Rotate(new Vector3(0, 180, 0));
             dreta = !dreta;
        }
 
    }

    void Jump()
    {
        animator.SetBool("isJumping", true);
        animator.SetBool("isFalling", false);
    }

    void JumpEnded()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }

    void Falling()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", true);
    }
}
