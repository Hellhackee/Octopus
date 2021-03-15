using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int _maxLevelScore;
    private int _money;
    private int _enemiesKilled = 0;
    private int _enemiesDodged = 0;
    private int _healthTaken = 0;

    public int EnemiesKilledCount => _enemiesKilled;
    public int EnemiesDodgedCount => _enemiesDodged;
    public int HealthTakenCount => _healthTaken;

    public int GetMaxLevelScore(string level, int currentLevelScore)
    {
        _maxLevelScore = PlayerPrefs.GetInt(level, 0);
        
        if (_maxLevelScore < currentLevelScore)
        {
            PlayerPrefs.SetInt(level, currentLevelScore);
            _maxLevelScore = currentLevelScore;
        }

        return _maxLevelScore;
    }

    public void ChangeMoney(int money)
    {
        _money += money;
        PlayerPrefs.SetInt("Money", _money);
    }

    public int GetMoney()
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        return money;
    }

    public void EnemyKilled()
    {
        _enemiesKilled++;
    }

    public void EnemyDodged()
    {
        _enemiesDodged++;
    }

    public void HealthTaken()
    {
        _healthTaken++;
    }
}
