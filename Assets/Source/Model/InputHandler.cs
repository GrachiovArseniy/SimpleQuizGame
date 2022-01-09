using System;

namespace Quiz.Model
{
    public class InputHandler
    {
        public InputHandler(Level level)
        {
            _level = level;
        }

        private readonly Level _level;

        public void Input(char c)
        {
            _level.TryGuess(Convert.ToChar(c.ToString().ToLower()));
        }
    }
}