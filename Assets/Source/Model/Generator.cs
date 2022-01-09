namespace Quiz.Model
{
    public class Generator
    {
        public Generator(Words words)
        {
            _words = words;
        }

        private readonly Words _words;

        internal string Generate()
        {
            return _words.Get(new System.Random().Next(0, _words.Count));
        }
    }
}