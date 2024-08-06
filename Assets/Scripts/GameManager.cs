using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerScore = 0;

    public void AddScore(int scoreToAdd)
    {
        _playerScore += scoreToAdd;
        Debug.Log("SCORE!!! Current score: " + _playerScore.ToString());
    }

}
