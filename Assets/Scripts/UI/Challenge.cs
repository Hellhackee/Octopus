using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Challenge : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _challengeDoneColor;
    
    private ChallengeSO _chosenChallenge;
    private int _award;
    private Animator _animator;
 
    private void Start()
    {
        _animator = GetComponent<Animator>();        
    }

    public void Init(ChallengeSO challenge)
    {
        _chosenChallenge = challenge;
        _text.text = _chosenChallenge.Name;
    }

    public int GetAward(int enemiesKilled, int enemiesDodged, int healthTaken, int score)
    {
        _award = _chosenChallenge.GetAward(healthTaken, score, enemiesKilled, enemiesDodged);

        if (_award > 0)
        {
            _text.color = _challengeDoneColor;
            _animator.Play("ChallengeDone");
        }

        return _award;
    }
}
