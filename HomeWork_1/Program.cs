using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeWork_1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var game = new BnbGame("Questions.csv");
            game.EndOfGame += (sender, eventArgs) =>
            {
                Console.WriteLine($"Questions asked:{eventArgs.QuestionPassed}. Mistakes made: {eventArgs.MistakeMode}");
                Console.WriteLine(eventArgs.IsWin ? "You Won" : "You Lost!");
            };
            while(game.GameStatus == GameStatus.GameInProgress)
            {
                Question q = game.GetNextQuestion();
                Console.WriteLine("Dou you belive in the next statment or quetion? Enter 'y' or 'n'");
                Console.WriteLine(q.Text);
                string answer = Console.ReadLine();
                bool boolAnswer = answer == "y";
                if (q.Correct == boolAnswer)
                {
                    Console.WriteLine("Good job.");
                }
                else
                {
                    Console.WriteLine("Actually you're mistaken.");
                    Console.WriteLine(q.Explanation);
                }
                game.GiveAnswer(boolAnswer);
            }
        }




        static void ChessPlayersHomeWork()
        {
            var players = File.ReadAllLines(@"Top100ChessPlayers.csv")
                             .Skip(1)
                             .Select(x => ChessPlayersRus.ParseFideCsvLine(x))
                             .Where(player => player.Country == "RUS")
                             .OrderBy(player => player.Rating)
                             .ToList();
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
