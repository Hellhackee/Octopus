using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    private int _maxLevelScore;
    private int _money;

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
}
