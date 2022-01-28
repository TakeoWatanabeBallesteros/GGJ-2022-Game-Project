using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving => _isMoving;
    private bool _canMove = true;
    public bool CanMove { get { return _canMove; } }

    [SerializeField]
    private float Speed = 5;

    public bool _isMoving;
    Rigidbody2D _rigidbody;

    Vector2 direction;

    private Controls controls;
    private Controls Controls{
        get{
            if(controls != null) {return controls;}
            return controls = new Controls();
        }
    }

    void OnEnable() {
        Controls.Player.Move.Enable();
        Controls.Player.Move.performed += ctx => direction = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled += ctx => direction = Vector2.zero;
    }

    void OnDisable() {
        Controls.Player.Move.Disable();
        Controls.Player.Move.performed -= ctx => direction = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled -= ctx => direction = Vector2.zero;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(direction.x * Speed, _rigidbody.velocity.y);
        _isMoving = _rigidbody.velocity.magnitude > 0.01f;
    }
    public void EnableMovement(){
        Controls.Player.Move.Enable();
        _canMove = true;
    }
    public void DisableMovement(){
        Controls.Player.Move.Disable();
        _canMove = false;
    }
}
