using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MusicButton : MonoBehaviour
{
    [SerializeField] private Sprite _onIcon;
    [SerializeField] private Sprite _offIcon;
    [SerializeField] private Music _music;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnButtonPressed()
    {
        if (_music.IsOn == 1)
        {
            SetSprite(0);
            _music.SetValue(0);
        }
        else
        {
            SetSprite(1);
            _music.SetValue(1);
        }
    }

    public void SetSprite(int isOn)
    {
        if (isOn == 1)
        {
            _image.sprite = _onIcon;
        }
        else
        {
            _image.sprite = _offIcon;
        }
    }
}
