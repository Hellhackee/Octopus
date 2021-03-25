using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ChallengeType
{
    Lifes3, kill100, kill300,  dontdodge5
}

[CreateAssetMenu(fileName = "NewChallenge", menuName = "CreateNewChallenge", order = 51)]
public class ChallengeSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _moneyAward;
    [SerializeField] private ChallengeType _type;

    public string Name => _name;

    public int GetAward(int healthTaken,  int score, int enemiesKilled, int enemiesDodged)
    {
        int award = 0;

        switch (_type)
        {
            case ChallengeType.Lifes3:
                
                if (healthTaken >= 3)
                    award = _moneyAward;
                
                break;
            case ChallengeType.kill100:
                
                if (enemiesKilled >= 100)
                    award = _moneyAward;

                break;
            case ChallengeType.kill300:

                if (enemiesKilled >= 300)
                    award = _moneyAward;

                break;
            case ChallengeType.dontdodge5:

                if (enemiesDodged < 5)
                    award = _moneyAward;
                break;
        }

        return award;
    }
}

