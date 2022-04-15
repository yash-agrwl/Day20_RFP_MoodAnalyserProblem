using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class TestMoodAnalyser
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
        //Arrange
        [DataRow("I am in Any Mood", "HAPPY")]
        public void GivenAnyMoodShouldReturnHappy(string message, string expected)
        {
            //Arrange
            MoodAnalyser mood = new(message);

            //Act
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 2.1: Given null message should return HAPPY.
        /// </summary>
        [TestMethod]
        //Arrange
        [DataRow(null, "HAPPY")]
        public void GivenNullMoodShouldReturnHappy(string message, string expected)
        {
            //Arrange
            MoodAnalyser mood = new(message);

            //Act
            string actual = mood.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
