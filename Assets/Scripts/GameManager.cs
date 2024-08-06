using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Score")]
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private Text _scoreText;

    [Header("Time")]
    [SerializeField] private float _timeInSeconds;
    [SerializeField] private Text _timeText;

    [Header("Health")]
    //[SerializeField] private int _playerHealth = 3;
    public int _playerHealth = 3;
    [SerializeField] private Text _healthText;

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
        /* Should player's isAlive logic go in here?? */
    }

    private void DisplayTime()
    {
        _timeInSeconds += Time.deltaTime;
        int _mm = Mathf.FloorToInt(_timeInSeconds / 60f);
        int _ss = Mathf.FloorToInt(_timeInSeconds % 60f);
        int _ms = Mathf.FloorToInt((_timeInSeconds * 1000) % 1000f);
        _timeText.text = "Time: " + string.Format("{0:00}:{1:00}:{2:000}", _mm, _ss, _ms);
    }

}
