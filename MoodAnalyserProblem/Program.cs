using System;

namespace MoodAnalyserProblem
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Mood Analyser Problem.\n");

            string message = "I am in a Sad Mood";
            MoodAnalyser mood1 = new(message);
            Console.WriteLine("Given message is: " + message);
            Console.WriteLine("The returned value is: "+ mood1.AnalyseMood());

            message = "I am in a Happy Mood";
            MoodAnalyser mood2 = new("I am in a Happy Mood");
            Console.WriteLine("\nGiven message is: " + message);
            Console.WriteLine("The returned value is: " + mood2.AnalyseMood());

            try
            {
                message = null;
                MoodAnalyser mood3 = new(message);
                Console.WriteLine("\nGiven message is null");
                Console.WriteLine("The returned value is: " + mood3.AnalyseMood());
            }
            catch (MoodAnalyserCustomException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }

            try
            {
                message = "";
                MoodAnalyser mood3 = new(message);
                Console.WriteLine("\nGiven message is empty");
                Console.WriteLine("The returned value is: " + mood3.AnalyseMood());
            }
            catch (MoodAnalyserCustomException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
        }
    }
}
