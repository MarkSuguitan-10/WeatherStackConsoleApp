using System;
using System.Collections.Generic;
using System.Text;
using WeatherStackLibrary.Process;

namespace WeatherStackLibrary.Questions
{
    public interface IQuestionModel
    {
        public char QuestionID { get; set; }
        public string Question { get; set; }
        public IResponse Response { get; set; }
    }
}
