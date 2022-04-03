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
            MoodAnalyser mood = new();

            //Act
            string actual = mood.AnalyseMood(message);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
