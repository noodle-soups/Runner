using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [Header("References")]
    public GameManager _gameManager;
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement")]
    private float _xInput;
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    protected private bool isGrounded;

    [Header("Alive")]
    public bool isAlive = true;


    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        Debug.Log(isAlive);

        if (_gameManager._playerHealth < 0)
            isAlive = false;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * _moveSpeed, _rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _xInput = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }

    // ground check
    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    // gizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }

}
