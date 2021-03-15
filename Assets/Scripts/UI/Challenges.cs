using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Challenges : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _challengeDoneColor;
    
    private Stats _stats;
    private Player _player;
    private Challenge _chosenChallenge;
    private int _award;
    private Animator _animator;
    private List<Challenge> _challenges = new List<Challenge>();
    private ChallengeContainer _container;

    private void Start()
    {
        _container = GameObject.FindObjectOfType<ChallengeContainer>();
        _stats = Camera.main.GetComponent<Stats>();
        _player = GameObject.FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();        
    }

    public void Init(Challenge challenge)
    {
        _chosenChallenge = challenge;
        _text.text = _chosenChallenge.Name;
    }

    private void OnLevelFinished()
    {
        int enemiesKilled = _stats.EnemiesKilledCount;
        int enemiesDodged = _stats.EnemiesDodgedCount;
        int healthTaken = _stats.HealthTakenCount;
        int score = _player.Score;

        _award = _chosenChallenge.GetAward(healthTaken, score, enemiesKilled, enemiesDodged);

        if (_award > 0)
        {
            _text.color = _challengeDoneColor;
            _animator.Play("ChallengeDone");
        }
    }
}
