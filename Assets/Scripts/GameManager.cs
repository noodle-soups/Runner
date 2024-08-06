using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private Text _scoreText;

    public void AddScore(int scoreToAdd)
    {
        _playerScore += scoreToAdd;
        _scoreText.text = "Score: " + _playerScore.ToString();
    }

}
