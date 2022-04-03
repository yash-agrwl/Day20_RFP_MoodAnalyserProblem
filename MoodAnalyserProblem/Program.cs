using System;

namespace MoodAnalyserProblem
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Mood Analyser Problem.\n");

            MoodAnalyser mood = new();
            Console.WriteLine(mood.AnalyseMood("I am in a Sad Mood"));
            Console.WriteLine(mood.AnalyseMood("I am in a Happy Mood"));
        }
    }
}
