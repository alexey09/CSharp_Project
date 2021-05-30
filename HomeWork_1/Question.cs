namespace HomeWork_1
{
    partial class Program
    {
        public class Question
        {
            public Question(string text, bool correct, string explanation)
            {
                Text = text;
                Correct = correct;
                Explanation = explanation;
            }

            public string Text { get; }
            public bool Correct { get; }
            public string Explanation { get; }
        }
    }
}
