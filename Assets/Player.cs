using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement")]
    private Vector2 _moveDir = Vector2.zero;
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    [Header("Input Actions")]
    [SerializeField] private PlayerInputActions _inputActions;
    private InputAction _move;
    private InputAction _fire;
    private InputAction _jump;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        // move
        _move = _inputActions.Player.Move;
        _move.Enable();

        // fire
        _fire = _inputActions.Player.Fire;
        _fire.Enable();
        _fire.performed += Fire;

        // jump
        _jump = _inputActions.Player.Jump;
        _jump.Enable();
        _jump.performed += Jump;

    }

    private void OnDisable()
    {
        _move.Disable();
        _fire.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _moveDir = _move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDir.x * _moveSpeed, _rb.velocity.y);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("FIRE!!!");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("JUMP!!!");
    }
}
