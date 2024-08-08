using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("References")]
    public Player _player;
    [SerializeField] private GameObject _gameOverUI;

    [Header("Score")]
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private Text _scoreText;

    [Header("Time")]
    [SerializeField] private float _timeInSeconds;
    [SerializeField] private Text _timeText;

    [Header("Health")]
    public int _playerHealth = 3;
    [SerializeField] private Text _healthText;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        DisplayTime();
    }

    public void AddScore(int scoreToAdd)
    {
        _playerScore += scoreToAdd;
        _scoreText.text = "Score: " + _playerScore.ToString();
    }

    public void DamageHealth(int damageHealthBy)
    {
        _playerHealth += -damageHealthBy;
        _healthText.text = "Health: " + _playerHealth.ToString();
        if (_playerHealth < 0)
        {
            _player._isAlive = false;
            GameOver();
        }
    }

    private void GameOver()
    {
        _gameOverUI.SetActive(true);
    }

    private void DisplayTime()
    {
        if (_player._isAlive)
        {
            _timeInSeconds += Time.deltaTime;
            int _mm = Mathf.FloorToInt(_timeInSeconds / 60f);
            int _ss = Mathf.FloorToInt(_timeInSeconds % 60f);
            int _ms = Mathf.FloorToInt((_timeInSeconds * 1000) % 1000f);
            _timeText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:000}", _mm, _ss, _ms);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
