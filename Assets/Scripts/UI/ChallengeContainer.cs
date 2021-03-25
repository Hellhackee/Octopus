using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeContainer : MonoBehaviour
{
    [SerializeField] private Challenge _challengePrefab;
    [SerializeField] private List<ChallengeSO> _allChallenges = new List<ChallengeSO>();
    [SerializeField] private Stats _stats;
    [SerializeField ]private Player _player;

    private List<Challenge> _chosenChallenges = new List<Challenge>();

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (TryGetChallenge(out ChallengeSO challenge))
            {
                Challenge chosenChallenge = Instantiate(_challengePrefab, transform);
                chosenChallenge.Init(challenge);
                
                _allChallenges.Remove(challenge);
                _chosenChallenges.Add(chosenChallenge);
            }
        }
    }

    private bool TryGetChallenge(out ChallengeSO challenge)
    {
        if (_allChallenges.Count > 0)
            challenge = _allChallenges[Random.Range(0, _allChallenges.Count)];
        else
            challenge = null;
        
        return challenge != null;
    }

    public int GetAwards()
    {
        int enemiesKilled = _stats.EnemiesKilledCount;
        int enemiesDodged = _stats.EnemiesDodgedCount;
        int healthTaken = _stats.HealthTakenCount;
        int score = _player.Score;
        int award = 0;

        foreach (Challenge challenge in _chosenChallenges)
        {
            award += challenge.GetAward(healthTaken, score, enemiesKilled, enemiesDodged);
        }

        _stats.ChangeMoney(award);

        return award;
    }
}
