using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += ChangeScoreLabel;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= ChangeScoreLabel;
    }

    private void ChangeScoreLabel(int value)
    {
        _scoreLabel.text = value.ToString();
    }
}
