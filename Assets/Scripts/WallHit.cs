using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private float _wallSpeed = 5f;
    [SerializeField] private float _deadZone = -20f;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        WallMovement();
    }

    private void WallMovement()
    {
        transform.position = transform.position + (Vector3.left * _wallSpeed) * Time.deltaTime;
        if (transform.position.x < _deadZone)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _gameManager.DamageHealth(1);
    }


}
