using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _startButton;

    public void OnCloseButtonPressed()
    {
        _levelsPanel.SetActive(false);
        _startButton.SetActive(true);
    }

    public void OnStartButtonPressed()
    {
        _levelsPanel.SetActive(true);
        _startButton.SetActive(false);
    }
}
