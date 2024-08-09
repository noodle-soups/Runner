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
    private AudioSource _jumpSFX;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    protected private bool _isGrounded;

    [Header("States")]
    public bool _isAlive = true;
    public bool _isFacingRight = true;


    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        _jumpSFX = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        FlipCheck();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * _moveSpeed, _rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (_isAlive)
            _xInput = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && _isAlive && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _jumpSFX.Play();
        }
        
        if (context.canceled && _rb.velocity.y > 0f && _isAlive)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }

    // ground check
    private void GroundCheck()
    {
        _isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    // flip
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 _localScale = transform.localScale;
        _localScale.x *= -1f;
        transform.localScale = _localScale;
    }

    // check if flip is needed
    private void FlipCheck()
    {
        if (!_isFacingRight && _xInput > 0f)
            Flip();
        else if (_isFacingRight && _xInput < 0f)
            Flip();
    }

    // gizmos
    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }

}
