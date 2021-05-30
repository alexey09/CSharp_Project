using System;

namespace HomeWork_1
{
    public class GameResultEventArgs : EventArgs
    {
        public GameResultEventArgs(int questionPassed, int mistakeMode, bool isWin)
        {
            QuestionPassed = questionPassed;
            MistakeMode = mistakeMode;
            IsWin = isWin;
        }

        public int QuestionPassed { get; }
        public int MistakeMode { get; }
        public bool IsWin { get; }
    }
}
