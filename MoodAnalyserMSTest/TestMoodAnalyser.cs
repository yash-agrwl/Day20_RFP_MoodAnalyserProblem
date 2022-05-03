using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using System.Reflection;

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

        /// <summary>
        /// TC 3.1: Given NULL Mood Should Throw MoodAnalyserCustomException Indicating Null Mood.
        /// </summary>
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalyserCustomException()
        {
            try
            {
                string message = null;
                MoodAnalyser mood = new(message);
                string actual = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }

        /// <summary>
        /// TC 3.2: Given Empty Mood Should Throw MoodAnalyserCustomException Indicating Empty Mood.
        /// </summary>
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalyserCustomException()
        {
            try
            {
                string message = "";
                MoodAnalyser mood = new(message);
                string actual = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }

        /// <summary>
        /// TC 4.1: Given MoodAnalyser Class Name should return MoodAnalyser Object.
        /// </summary>
        [TestMethod]
        [DataRow("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser")]
        [DataRow("MoodAnalyserProblem.MoodAnalyser", "Mood")]
        [DataRow("MoodAnalyserProblem.Mood", "Mood")]
        public void GivenMoodAnalyserClassName_ShouldReturnObject_UsingDefaultConstructor(string className, string constructorName)
        {
            try
            {
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserReflector.CreateMoodAnalyserUsingDefaultConstructor(className, constructorName);
                expected.Equals(obj);
                //bool flag = expected == obj; // Alternate Statement.
            }
            catch (MoodAnalyserCustomException e)
            {
                if (e.Message == "Constructor is Not Found")
                    Assert.AreEqual("Constructor is Not Found", e.Message);
                else if (e.Message == "Class Not Found")
                    Assert.AreEqual("Class Not Found", e.Message);
            }
        }

        /// <summary>
        /// TC 5.1: Given MoodAnalyser Class Name Should return MoodAnalyser Object.
        /// </summary>
        [TestMethod]
        [DataRow("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "HAPPY")]
        [DataRow("MoodAnalyserProblem.MoodAnalyser", "Mood", "HAPPY")]
        [DataRow("MoodAnalyserProblem.Mood", "MoodAnalyser", "HAPPY")]
        public void GivenMoodAnalyserClassName_ShouldReturnObject_UsingParameterizedConstructor(string className, string constructorName, string message)
        {
            object expected = new MoodAnalyser(message);
            try
            {
                object obj = MoodAnalyserReflector.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, message);
                expected.Equals(obj);
            }
            catch (MoodAnalyserCustomException e)
            {
                if (e.Message == "Constructor is Not Found")
                    Assert.AreEqual("Constructor is Not Found", e.Message);
                else if (e.Message == "Class Not Found")
                    Assert.AreEqual("Class Not Found", e.Message);
            }
        }

        /// <summary>
        /// TC 6.1 & 6.2: Given Happy Message Using Reflection Should Return Happy.
        /// </summary>
        [TestMethod]
        [DataRow("Happy", "AnalyseMood")]
        [DataRow(null, "AnalyseMood")]
        [DataRow("Happy", "ImproperMethod")]
        public void GivenHappyMessageUsingReflectorShouldReturnHappy(string message, string methodName)
        {
            string expected = "HAPPY";
            try
            {
                string actual = MoodAnalyserReflector.InvokeAnalyseMood(message, methodName);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                if(e.Message == "Method is Not Found")
                    Assert.AreEqual("Method is Not Found", e.Message);
                else if (e.Message == "Improper Message entered")
                    Assert.AreEqual("Improper Message entered", e.Message);
            }
        }

        /// <summary>
        /// TC7.1: Given Happy Message use Reflection to Set the Field value and return Happy.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        [TestMethod]
        [DataRow("HAPPY", "Message")]
        [DataRow("HAPPY", "ImproperField")]
        [DataRow(null, "Message")]
        public void GivenHappyMessage_ShouldSetFieldUsingReflection_AndReturnHappy(string message, string fieldName)
        {
            string expected = message;
            try
            {
                string actual = MoodAnalyserReflector.SetField(message, fieldName);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                if (e.Message == "Field is not Found")
                    Assert.AreEqual("Field is not Found", e.Message);
                else if (e.Message == "Message should not be null")
                    Assert.AreEqual("Message should not be null", e.Message);
            }
        }
    }
}
