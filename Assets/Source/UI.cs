using System.Collections;
using System.Collections.Generic;
using Quiz.Model;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _chars;
    [SerializeField] private Text _attemptsText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Animation _wrongAnswer;
    [SerializeField] private Animation _wordGuessed;
    [SerializeField] private Animation _gameLosed;
    [SerializeField] private Animation _gameWinned;
    [SerializeField] private Text _resultText;
    [SerializeField] private string _winnedText;
    [SerializeField] private string _losedText;

    private Level _level;

    public void Init(Level level)
    {
        _level = level;
    }

    public void OnWrongAnswer()
    {
        _wrongAnswer.Play();
        UpdateAttemptsText();
    }

    public void OnWordGuessed()
    {
        _wordGuessed.Play();
        UpdateAttemptsText();
        UpdateScoreText();
        StartCoroutine(EnableChars());
    }

    public void OnGameLosed()
    {
        _gameLosed.Play();
        _resultText.text = _losedText;
    }

    public void OnGameWinned()
    {
        _gameWinned.Play();
        _resultText.text = _winnedText;
    }

    private void UpdateAttemptsText()
    {
        _attemptsText.text = _level.Attempts.ToString();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _level.Score.ToString();
    }

    private IEnumerator EnableChars()
    {
        yield return new WaitForSeconds(0.1f);

        _chars.ForEach(i => i.SetActive(true));
    }
}
