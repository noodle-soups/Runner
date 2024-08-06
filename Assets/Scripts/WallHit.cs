using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour
{

    public GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _gameManager.DamageHealth(1);
    }


}
