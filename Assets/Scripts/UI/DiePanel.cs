using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class DiePanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _score;
    [SerializeField] private Text _maxScore;
    [SerializeField] private Stats _prefs;
    [SerializeField] private ProgressBar _progressBar;

    private Animator _animator;
    private Vector3 _startPosition;
    private int _currentLevel;

    private void Start()
    {
        _startPosition = transform.position;
        _animator = GetComponent<Animator>();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _progressBar.LevelFinished += OnLevelFinished;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _progressBar.LevelFinished -= OnLevelFinished;
        transform.position = _startPosition;
    }

    private void OnPlayerDied()
    {
        _animator.Play("DiePanel");
        _score.text = _player.Score.ToString();
        string level = "Level" + (_currentLevel + 1).ToString();
        _maxScore.text = _prefs.GetMaxLevelScore(level, _player.Score).ToString();
    }

    private void OnLevelFinished()
    {
        _animator.Play("DiePanel");
        _score.text = _player.Score.ToString();
        string level = "Level" + (_currentLevel + 1).ToString();
        _maxScore.text = _prefs.GetMaxLevelScore(level, _player.Score).ToString();
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(_currentLevel);
    }
}
