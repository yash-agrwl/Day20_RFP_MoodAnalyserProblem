using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// UC 4: Create Object of MoodAnalyser class with Default Constructor using Reflection.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyserUsingDefaultConstructor(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            //bool result = Regex.IsMatch(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }

        /// <summary>
        /// UC5: Create Object of MoodAnalyser class with Parameterized Constructor using Reflection.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException"></exception>
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            //Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyser"); // Alternate Statement.

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }
        }

        /// <summary>
        /// UC6: Use Reflection to invoke AnalyseMood Method.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException"></exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyserReflector.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                try
                {
                    object mood = analyseMoodInfo.Invoke(moodAnalyserObject, null);
                    return mood.ToString();
                }
                catch (TargetInvocationException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.IMPROPER_MESSAGE, "Improper Message entered");
                }

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }

        /// <summary>
        /// UC7: Use Reflection to set the field value dynamically.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException"></exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser obj = (MoodAnalyser)MoodAnalyserReflector.CreateMoodAnalyserUsingDefaultConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

                if (message == null)
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NULL_MESSAGE, "Message should not be null");

                field.SetValue(obj, message);
                return obj.Message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELD, "Field is not Found");
            }
        }
    }
}
