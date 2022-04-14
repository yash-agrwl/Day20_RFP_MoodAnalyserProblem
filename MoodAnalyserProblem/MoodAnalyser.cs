using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {

        private string Message;

        public MoodAnalyser(string message)
        {
            this.Message = message;
        }

        public string AnalyseMood()
        {
            try
            {
                if (this.Message.ToLower().Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
