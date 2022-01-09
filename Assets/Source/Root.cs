using UnityEngine;
using Quiz.Model;

public class Root : MonoBehaviour
{
    [SerializeField] private Config _config;
    [SerializeField] private TextAsset _gameText;
    [SerializeField] private InputHandlerPresenter _inputHandlerPresenter;
    [SerializeField] private GameResultHandler _gameResultHandler;
    [SerializeField] private WordHandler _wordHandler;
    [SerializeField] private WordBuilder _wordBuilder;
    [SerializeField] private UI _ui;

    private Generator _generator;
    private InputHandler _inputHandler;
    private Level _level;
    private Words _words;

    private void Awake()
    {
        _words = new Words(_gameText.text, _config.MinLength);
        _generator = new Generator(_words);
        _level = new Level(_generator, _config.Attempts);
        _inputHandler = new InputHandler(_level);

        _gameResultHandler.Init(_level, _ui);
        _inputHandlerPresenter.Init(_inputHandler);
        _wordHandler.Init(_level, _wordBuilder);
        _ui.Init(_level);

        _level.Start();
    }
}
