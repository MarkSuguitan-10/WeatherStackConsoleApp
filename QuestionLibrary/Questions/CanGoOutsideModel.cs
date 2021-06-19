using System;
using System.Collections.Generic;
using System.Text;
using WeatherStackLibrary.Process;

namespace WeatherStackLibrary.Questions
{
    public class CanGoOutsideModel : IQuestionModel
    {
        public char QuestionID { get; set; }
        public string Question { get; set; }
        public IResponse Response { get; set; } = new CanGoOutside();

    }
}
