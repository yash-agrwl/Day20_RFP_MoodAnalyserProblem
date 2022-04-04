using System;

namespace MoodAnalyserProblem
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Mood Analyser Problem.\n");

            MoodAnalyser mood1 = new("I am in a Sad Mood");
            Console.WriteLine(mood1.AnalyseMood());

            MoodAnalyser mood2 = new("I am in a Happy Mood");
            Console.WriteLine(mood2.AnalyseMood());
        }
    }
}
