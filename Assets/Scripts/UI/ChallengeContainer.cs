using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeContainer : MonoBehaviour
{
    [SerializeField] private Challenges _challengePrefab;
    [SerializeField] private List<Challenge> _challenges = new List<Challenge>();

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (TryGetChallenge(out Challenge challenge))
            {
                Challenges challengePrefab = Instantiate(_challengePrefab, transform);
                challengePrefab.Init(challenge);
                _challenges.Remove(challenge);
            }
        }
    }

    private bool TryGetChallenge(out Challenge challenge)
    {
        if (_challenges.Count > 0)
            challenge = _challenges[Random.Range(0, _challenges.Count)];
        else
            challenge = null;
        
        return challenge != null;
    }
}
