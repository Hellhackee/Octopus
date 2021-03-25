using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Text _levelIndex;

    public void OnButtonPressed()
    {
        int level = int.Parse(_levelIndex.text);
        SceneManager.LoadScene(level);
    }
}
