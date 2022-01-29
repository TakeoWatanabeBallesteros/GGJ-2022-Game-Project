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

    [SerializeField]
    GameObject particleOne;
    [SerializeField]
    GameObject PowerUp;
    [SerializeField]
    GameObject Dust;
    [SerializeField]
    ParticleSystem Walk;
    GameObject player;

    bool isMoving;

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
        StopWalk();
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
        Controls.Player.Move.canceled += ctx => StopWalk();
        jump.onJump += Jump;
        groundCheck.OnLanded += JumpEnded;
        jump.onPeak += Falling;
        EnergyBall.OnEnergyBallCollected += Electrocuted;
    }

    private void OnDisable()
    {
        Controls.Player.Move.Disable();
        Controls.Player.Move.performed -= ctx => Speed(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled -= ctx => StopWalk();
        jump.onJump -= Jump;
        groundCheck.OnLanded -= JumpEnded;
        jump.onPeak -= Falling;
        EnergyBall.OnEnergyBallCollected -= Electrocuted;
    }

    public void Speed(Vector2 vector)
    {
        isMoving = true;
        Walk.Play();
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
        Walk.Stop();
        animator.SetBool("isJumping", true);
        animator.SetBool("isFalling", false);

        if(gameObject.layer == LayerMask.NameToLayer("Player_2"))
        {
            Instantiate(Dust, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z - 0.5f), Quaternion.identity, transform);
        }
        else
        {
            Instantiate(Dust, new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z - 0.5f), Quaternion.identity, transform);
        }
    }

    void JumpEnded()
    {
        if(isMoving) Walk.Play();
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }

    void Falling()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", true);
    }

    void Electrocuted(GameObject obj, bool condicio, float num)
    {
        if(obj == this.gameObject)
        {
            Instantiate(particleOne, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Quaternion.identity, transform);
        }
        /*else
        {
            if(gameObject.layer == LayerMask.NameToLayer("Player_1"))
            {
                Instantiate(PowerUp, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z - 1f), Quaternion.EulerAngles(Mathf.Deg2Rad * 90, 0, 0), transform);
            }
            else
            {
                Instantiate(PowerUp, new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z - 1f), Quaternion.EulerAngles(Mathf.Deg2Rad * -90, 0, 0), transform);
            }
        }*/
    }

    void StopWalk()
    {
        isMoving = false;
        Walk.Stop();
    }
}
