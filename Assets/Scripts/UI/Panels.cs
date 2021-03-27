using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{
    [SerializeField] private EndPanel _diePanel;
    [SerializeField] private EndPanel _finishPanel;
    [SerializeField] private Player _player;
    [SerializeField] private ProgressBar _progressBar;

    private void OnEnable()
    {
        _player.Died += OnEnemyDied;
        _progressBar.LevelFinished += OnLevelFinished;
    }

    private void OnDisable()
    {
        _player.Died -= OnEnemyDied;
        _progressBar.LevelFinished -= OnLevelFinished;
    }

    private void OnEnemyDied()
    {
        _player.Disable("Die");
        _progressBar.LevelFinished -= OnLevelFinished;
        _diePanel.gameObject.SetActive(true);
    }

    private void OnLevelFinished()
    {
        _player.Disable("Idle");
        _player.Died -= OnEnemyDied;
        _finishPanel.gameObject.SetActive(true);
    }
}
