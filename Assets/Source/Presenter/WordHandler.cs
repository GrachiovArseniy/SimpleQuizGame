using System.Linq;
using Quiz.Model;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    public void Init(Level level, WordBuilder wordBuilder)
    {
        _level = level;
        _wordBuilder = wordBuilder;

        _level.CharGuessed += OpenSquare;
        _level.WordUpdated += OnWordUpdated;
    }

    private Square[] _squares = new Square[0];
    private WordBuilder _wordBuilder;
    private Level _level;

    private void OpenSquare(int id)
    {
        _squares[id].Open();
    }

    private void OnWordUpdated(string newWord)
    {
        _squares.ToList().ForEach(i => Destroy(i.gameObject));
        _squares = _wordBuilder.Build(newWord).ToArray();
        Debug.Log(newWord);
    }

    private void OnDisable()
    {
        _level.CharGuessed -= OpenSquare;
        _level.WordUpdated -= OnWordUpdated;
    }
}
