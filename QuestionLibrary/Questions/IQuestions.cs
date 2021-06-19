using System.Threading.Tasks;

namespace WeatherStackLibrary.Questions
{
    public interface IQuestions
    {
        void DisplayQuestions();
        Task<QuestionModel> SelectQuestion();
    }
}