using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_1
{
    public enum GameStatus
    {
        GameIsOver,
        GameInProgress
    }
    class BnbGame
    {
        private static string filePath;
        private readonly string questions;
        private readonly int allowedMistakes;
        private int counter;
        private int mistakes;
        public event EventHandler<GameResultEventArgs> EndOfGame;

        public GameStatus GameStatus { get; private set; }

        public Question GetNextQuestion()
        {
            return questions[counter];
        }
        public void GiveAnswer(bool answer)
        {
            if (questions[counter].Correct != answer)
            {
                mistakes++;
            }
            if (counter == questions.Count - 1 || mistakes > allowedMistakes)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(this, new GameResultEventArgs(counter, mistakes, mistakes <= allowedMistakes));
            }
            counter++;
        }
        public BnbGame(string filePath, int allowedMistakes = 3)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            if (filePath == "")
            {
                throw new ArgumentNullException("filePath should not be empty");
            }
            if (allowedMistakes < 2)
                throw new AggregateException("allowedMistakes should be >= 2");
            this.allowedMistakes = allowedMistakes;
            IEnumerable<Question> questions = File.ReadAllLines(filePath)
                                                  .Select(x =>
                                                  {
                                                      string[] parts = x.Split(';');
                                                      string text = parts[0];
                                                      bool correct = parts[1] == "Yes";
                                                      string explanation = parts[2];
                                                      return new Question(text, correct, explanation);
                                                  })
                                                  .ToList();
        }
    }
}
