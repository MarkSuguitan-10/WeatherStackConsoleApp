using System.Collections.Generic;
using WeatherStackLibrary;
using WeatherStackLibrary.APIController;
using WeatherStackLibrary.Questions;

namespace WeatherStackUI.Dependency_Injection
{
    class DependencyFactory
    {
        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static IURL CreateURL(string baseURL, string zipCode, string Access_Key)
        {
           return  new URL(baseURL, zipCode, Access_Key);
        }

        public static IQuestions CreateQuestions(List<IQuestionModel> questions, ILogger logger, IURL url)
        { 
            return new Questions(questions, logger, url);
        }

         public static List<IQuestionModel> ListOfQuestions()
        { 
            return new List<IQuestionModel>();
        }
    }
}
