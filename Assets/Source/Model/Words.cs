using System.Linq;
using System.Collections.Generic;

namespace Quiz.Model
{
    public class Words
    {
        /// <summary></summary>
        /// <param name="text">The text from which the words are selected.</param>
        /// <param name="minLength"></param>
        public Words(string text, int minLength)
        {
            _minLength = minLength;
            string[] words = text.ToLower().Split().Distinct().ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = new string(words[i].ToCharArray().Where(c => char.IsLetter(c)).ToArray());
            }

            _list.AddRange(words.Where(i => i.Length >= _minLength).ToArray());
        }

        private readonly int _minLength;

        internal int Count => _list.Count;

        private readonly List<string> _list = new List<string>();

        /// <summary>
        /// After the call, received element is deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Random unique word.</returns>
        internal string Get(int id)
        {
            if (_list.Count == 0)
            {
                return string.Empty;
            }

            string result = _list[id];
            _list.Remove(result);
            _list.Distinct();
            return result;
        }
    }
}