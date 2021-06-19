using System;
using System.Collections.Generic;
using WeatherStackLibrary;
using WeatherStackLibrary.Questions;
using WeatherStackLibrary.APIController;
using WeatherStackLibrary.ZipCode;
using WeatherStackUI.Dependency_Injection;

namespace WeatherStackAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            string BaseURL = "http://api.weatherstack.com/";
            ////A3:2017-Sensitive Data Exposure
            ///Created library to hide the APIAccessKey
            var Access_Key = APIAccessKeyLibrary.APIAccessKey.GetAPIAccessKey();
            ILogger logger = DependencyFactory.CreateLogger();

            //Initialize Questions 
            List<IQuestionModel> listofquestions = DependencyFactory.ListOfQuestions();
            listofquestions.Add(new CanFlyKiteModel         { QuestionID = 'a', Question = "Can I fly my kite?" });
            listofquestions.Add(new CanGoOutsideModel       { QuestionID = 'b', Question = "Should I go outside?" });
            listofquestions.Add(new CanWearSunscreenModel   { QuestionID = 'c', Question = "Should I wear sunscreen?" });

            if (ConnectionProvider.CheckConnection(BaseURL, logger) == true)
            {
                string zipCode = string.Empty;
                do
                {
                    StandardMessages.EnterZipCodeMessage();
                    zipCode = ZipCodeCapture.GetZipCode();
                    Console.WriteLine(Environment.NewLine);
                }
                while (ZipCodeValidator.Validate(zipCode) == false);


                IURL url = DependencyFactory.CreateURL(BaseURL, zipCode, Access_Key);
                IQuestions questions = DependencyFactory.CreateQuestions(listofquestions, logger, url);
                do
                {
                    questions.DisplayQuestions();
                    QuestionModel choosenQuestion = questions.SelectQuestion().Result;

                    Console.WriteLine(choosenQuestion.Response);
                    Console.WriteLine(Environment.NewLine);
                }
                while (StandardMessages.TerminateMessage() != ConsoleKey.Escape);
            }
            else
            {
                StandardMessages.NoInternetMessage();
            }
        }
    }
}
