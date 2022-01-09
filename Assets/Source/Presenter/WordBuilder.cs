using System.Collections.Generic;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _squarePrefab;
    [SerializeField] private float _squareWigth = 0.15f;

    public IReadOnlyList<Square> Build(string word)
    {
        List<Square> squares = new List<Square>();

        float deltaPos = (word.Length - 1) * _squareWigth / 2 * -1;

        for (int i = 0; i < word.Length; i++)
        {
            squares.Add(Instantiate(_squarePrefab, this.transform).GetComponent<Square>());
            squares[i].SetChar(word[i]);
            squares[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(deltaPos, 0);
            deltaPos += _squareWigth;
        }

        return squares;
    }
}