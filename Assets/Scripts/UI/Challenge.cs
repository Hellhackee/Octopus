using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Challenge : MonoBehaviour
{
    
    [SerializeField] private Text _text;
    [SerializeField] private Color _challengeDoneColor;
    [SerializeField] private Sprite _winSprite;
    
    private ChallengeSO _chosenChallenge;
    private int _award;
    private Image _image;
 
    private void Start()
    {
        _image = GetComponent<Image>();
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
            _image.sprite = _winSprite;
        }

        return _award;
    }
}
