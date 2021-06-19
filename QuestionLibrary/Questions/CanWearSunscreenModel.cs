using WeatherStackLibrary.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackLibrary.Questions
{
    public class CanWearSunscreenModel : IQuestionModel
    {
        public char QuestionID { get; set; }
        public string Question { get; set; }
        public IResponse Response { get; set; } = new CanWearSunscreen();
    }
}
