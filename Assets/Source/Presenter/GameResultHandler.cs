using Quiz.Model;
using UnityEngine;

public class GameResultHandler : MonoBehaviour
{
    public void Init(Level level, UI ui)
    {
        _level = level;
        _ui = ui;

        _level.WrongAnswer += OnWrongAnswer;
        _level.WordGuessed += OnWordGuessed;
        _level.GameLosed += OnGameLosed;
        _level.GameWinned += OnGameWinned;
    }

    private Level _level;
    private UI _ui;

    private void OnWrongAnswer()
    {
        _ui.OnWrongAnswer();
    }

    private void OnWordGuessed()
    {
        _ui.OnWordGuessed();
    }

    private void OnGameLosed()
    {
        _ui.OnGameLosed();
    }

    private void OnGameWinned()
    {
        _ui.OnGameWinned();
    }

    private void OnDisable()
    {
        _level.WrongAnswer -= OnWrongAnswer;
        _level.WordGuessed -= OnWordGuessed;
        _level.GameLosed -= OnGameLosed;
        _level.GameWinned -= OnGameWinned;
    }
}