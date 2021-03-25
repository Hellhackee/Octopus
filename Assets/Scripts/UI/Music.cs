using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MusicButton _musicButton;
    
    private int _isOn;

    public int IsOn => _isOn;

    private void Awake()
    { 
        _isOn =  PlayerPrefs.GetInt("Music", 1);
        SetValue(_isOn);
        _musicButton.SetSprite(_isOn);
    }


    public void SetValue(int isOn)
    {
        if (isOn == 1)
        {
            _audioSource.volume = 1f;
        }
        else
        {
            _audioSource.volume = 0f;
        }

        _isOn = isOn;

        PlayerPrefs.SetInt("Music", _isOn);
    }
}
