using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Player _player;

    [Header("Spawn")]
    [SerializeField] private GameObject _wall;

    [Header("Timer")]
    [SerializeField] private float _timer = 0f;
    [SerializeField] private int _spawnTimer = 2;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SpawnWall();
    }

    void Update()
    {
        SpawnWallOnTimer();
    }

    private void SpawnWallOnTimer()
    {
        if (_player._isAlive)
            if (_timer < _spawnTimer)
                _timer += Time.deltaTime;
            else
            {
                SpawnWall();
                _timer = 0f;
            }
    }

    private void SpawnWall()
    {
        Instantiate(_wall, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }
}
