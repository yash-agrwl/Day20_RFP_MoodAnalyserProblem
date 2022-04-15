using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserCustomException : Exception
    {
        /// <summary>
        /// Enum for Exception Type.
        /// </summary>
        public enum ExceptionType
        {
            EMPTY_MESSAGE, NULL_MESSAGE
        }

        /// <summary>
        /// Creating 'type' variable of type ExceptionType
        /// </summary>
        public readonly ExceptionType Type;

        /// <summary>
        /// Parameterized Constructor sets the Exception Type and message.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public MoodAnalyserCustomException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }
    }
}
