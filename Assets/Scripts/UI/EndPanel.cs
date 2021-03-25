using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class EndPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _score;
    [SerializeField] private Text _maxScore;
    [SerializeField] private Stats _prefs;
    [SerializeField] private ParticleSystem _finishParticle;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ChallengeContainer _challengeContainer;

    private Animator _animator;
    private Vector3 _startPosition;
    private int _currentLevel;

    private void Awake()
    {
        _startPosition = transform.position;
        _animator = GetComponent<Animator>();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _animator.Play("EndPanel");
        _finishParticle.Play();
        _player.gameObject.SetActive(false);
        _spawner.gameObject.SetActive(false);
        _score.text = _player.Score.ToString();
        string level = "Level" + (_currentLevel + 1).ToString();
        _maxScore.text = _prefs.GetMaxLevelScore(level, _player.Score).ToString();

        if (_challengeContainer != null)
        {
            StartCoroutine(GetAwards());
        }
    }

    private void OnDisable()
    {
        transform.position = _startPosition;
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    private IEnumerator GetAwards()
    {
        yield return new WaitForSeconds(1f);

        int award = _challengeContainer.GetAwards();
        int finalScore = _player.Score + award;
        
        _score.text = finalScore.ToString();
    }

    public void OnMainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
