using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WeatherStackLibrary.Model;
using WeatherStackLibrary.APIController;
using System.Threading.Tasks;

namespace WeatherStackLibrary.Questions
{
    public class Questions : IQuestions
    {
        List<IQuestionModel> _listOfQuestions;
        ILogger _logger;
        IURL _url;

        public Questions(List<IQuestionModel> questions, ILogger logger, IURL url)
        {
            _listOfQuestions = questions;
            _logger = logger;
            _url = url;
        }

        public void DisplayQuestions()
        {
            Console.WriteLine("please select the number your question corresponds with:");
            foreach (IQuestionModel question in _listOfQuestions)
            {
                Console.WriteLine("{0} : {1}", question.QuestionID, question.Question);
            }
        }

        public async Task<QuestionModel> SelectQuestion()
        {
            QuestionModel output = new QuestionModel();
            IWeatherModel data = new WeatherModel();
            try
            {
                bool isSelectionSuccess = false;
                ConsoleKeyInfo key;

                data = await CallWeatherAPI.GetZipCodeWeatherData(_url);
                do
                {
                    key = Console.ReadKey(true);

                    if (Regex.IsMatch(key.KeyChar.ToString(), @"^[a-zA-Z]+$") == true)
                    {
                        isSelectionSuccess = _listOfQuestions.Exists(x => x.QuestionID == key.KeyChar);
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                while (isSelectionSuccess == false);

                IQuestionModel _question = _listOfQuestions.Find(x => x.QuestionID == key.KeyChar);
                output.Question = _question.Question;

                output.Response = _question.Response.Respond(data);
            }
            catch (Exception ee)
            {
                _logger.Log(ee.Message + ee.StackTrace);
            }
            return output;
        }


    }
}
