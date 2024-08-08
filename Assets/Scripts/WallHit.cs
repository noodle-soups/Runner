using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    private AudioSource _damageSFX;
    private GameManager _gameManager;
    private Player _player;
    [SerializeField] private float _wallSpeed = 5f;
    [SerializeField] private float _deadZone = -20f;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _damageSFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        WallMovement();
    }

    private void WallMovement()
    {
        if (_player._isAlive)
            transform.position = transform.position + (Vector3.left * _wallSpeed) * Time.deltaTime;
        if (transform.position.x < _deadZone)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.DamageHealth(1);
            _damageSFX.Play();
        }
    }


}
