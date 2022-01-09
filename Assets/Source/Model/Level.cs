using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Model
{
    public class Level
    {
        public Level(Generator generator, int attempts)
        {
            _generator = generator;
            _attempts = attempts;
            _deltaAttempts = attempts;
        }

        private readonly Generator _generator;
        private readonly int _attempts;
        private int _score;
        private int _deltaAttempts;
        private int _guessedChar;

        public string CurrentWord { get; private set; }

        public int Attempts => _deltaAttempts;

        public int Score => _score;

        public event Action<int> CharGuessed;

        public event Action<string> WordUpdated;

        public event Action WordGuessed;

        public event Action WrongAnswer;

        public event Action GameLosed;

        public event Action GameWinned;

        public void Start()
        {
            CurrentWord = _generator.Generate();
            WordUpdated?.Invoke(CurrentWord);
        }

        internal void TryGuess(char c)
        {
            List<int> ids = new List<int>();
            string deltaWord = CurrentWord;

            while (true)
            {
                if (deltaWord.Contains(c) == false)
                {
                    break;
                }

                ids.Add(deltaWord.IndexOf(c) + (CurrentWord.Length - deltaWord.Length));

                deltaWord = deltaWord.Remove(ids[^1] - (CurrentWord.Length - deltaWord.Length), 1);
            }

            if (ids.Count == 0)
            {
                _deltaAttempts--;

                WrongAnswer?.Invoke();

                if (_deltaAttempts < 0)
                {
                    GameLosed?.Invoke();
                }

                return;
            }

            foreach (var id in ids)
            {
                CharGuessed?.Invoke(id);
                _guessedChar++;
            }

            if (_guessedChar == CurrentWord.Length)
            {
                _score += _deltaAttempts;
                _deltaAttempts = _attempts;
                WordGuessed?.Invoke();
                NextWord();
            }
        }

        private void NextWord()
        {
            CurrentWord = _generator.Generate();
            _guessedChar = 0;

            if (CurrentWord == string.Empty)
            {
                GameWinned?.Invoke();
                return;
            }

            WordUpdated?.Invoke(CurrentWord);
        }
    }
}