using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TC 1.1: Given "I am in Sad Mood" message should return SAD.
        /// </summary>
        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyser mood = new(message);

            //Act
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 1.2: Given "I am in Any Mood" message should return HAPPY.
        /// </summary>
        [TestMethod]
        public void GivenAnyMoodShouldReturnHappy()
        {
            //Arrange
            string expected = "HAPPY";
            string message = "I am in Any Mood";
            MoodAnalyser mood = new();

            //Act
            string actual = mood.AnalyseMood(message);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
