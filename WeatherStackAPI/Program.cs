using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Configuration;
using WeatherStackAPI.APIController;
using WeatherStackAPI.Model;

namespace WeatherStackAPI
{
    class Program
    {
        private static string APIUrl = "http://api.weatherstack.com/";
        private static string Access_Key  = ConfigurationManager.AppSettings["AccessKey"];
        static async Task Main(string[] args)
        {
            
            if (CheckConnection(APIUrl) == true)
            {
                ConsoleKeyInfo terminateKey = new ConsoleKeyInfo();
                while(terminateKey.Key != ConsoleKey.Escape)
                { 
                    WeatherModel data = new WeatherModel();
                    do
                    {
                        Console.WriteLine("Enter US Zipcode:");
                        string zipcode = ReadInput();
                        URL.SetURL(APIUrl, Access_Key, zipcode);
                        data = await CallWeatherAPI.GetZipCodeWeatherData();
                        if (data.IsSuccess == true)
                        {
                            char question = ChooseUserQuestion();
                            Console.WriteLine(Environment.NewLine);
                            AnswerQuestion(question, data);
                        }
                        else
                        {
                            Console.WriteLine(String.Empty);
                            Console.WriteLine("ZipCode Error, please check your zipcode.");
                        }
                    }
                    while (data.IsSuccess == false);


                    Console.WriteLine("Press Escape to end program");
                    terminateKey = Console.ReadKey(true);
                    Console.WriteLine(String.Empty);
                }
            }
            else
            {
                Console.WriteLine("Please check connection and restart application.");
            }
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        /// <summary>
        /// Output response
        /// </summary>
        /// <param name="question"></param>
        /// <param name="data"></param>
        public static void AnswerQuestion(char question, WeatherModel data)
        {
            switch (question)
            {
                case 'a':
                    if (IsItRaining(data.Weather_Descriptions) == true)
                    {
                        Console.WriteLine("No, It is  raining.");
                    }
                    else
                    {
                        Console.WriteLine("Yes, It is not raining.");
                    }
                    break;
                case 'b':
                    if (Convert.ToInt32(data.UV_Index) > 3)
                    {
                        Console.WriteLine("Yes, you should wear sunscreen.");
                    }
                    else
                    {
                        Console.WriteLine("No, UV is only at {0}", data.UV_Index);
                    }
                    break;
                case 'c':
                    if (CanFlyKite(data.Weather_Descriptions, data.Wind_Speed) == true)
                    {
                        Console.WriteLine("Yes, It is perfect weather condition to fly kite.");
                    }
                    break;
            }
        }

        /// <summary>
        /// Check if input for zipCode is valid.
        /// </summary>
        /// <returns></returns>
        public static string ReadInput()
        {
            string finalValue = string.Empty;

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                ///Check if pressed is digit, backspace or length of text is over zipcode limit.
                if (key.Key != ConsoleKey.Backspace && finalValue.Length != 5)
                {
                    bool isDigit =  char.IsDigit(key.KeyChar);
                    if (isDigit == true)
                    {
                        finalValue += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && finalValue.Length > 0)
                    {
                        finalValue = finalValue.Substring(0, (finalValue.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter );

            return finalValue;
        }

        /// <summary>
        /// Question selector for user. 
        /// </summary>
        /// <returns>returns letter of question choice</returns>
        public static char ChooseUserQuestion()
        {
            char question = '0';
            Console.WriteLine("");
            Console.WriteLine("How can I help you today, please select letter?");
            Console.WriteLine("a.) Should I go outside?");
            Console.WriteLine("b.) Should I wear sunscreen?");
            Console.WriteLine("c.) Can I fly my kite?");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 'a' || key.KeyChar == 'b' || key.KeyChar == 'c')
                {
                    question = key.KeyChar;
                    Console.Write(key.KeyChar);
                    
                    break;
                }
                else
                {
                    Console.WriteLine("Please select the letter corresponding to your question.");
                    Console.WriteLine("a.) Should I go outside?");
                    Console.WriteLine("b.) Should I wear sunscreen?");
                    Console.WriteLine("c.) Can I fly my kite?");
                }
            }
            while (question == '0');
            return question;
        }

        /// <summary>
        /// Check internet connection
        /// </summary>
        /// <param name="URL">URL parameter to be checked.</param>
        /// <returns>returns true if can connect to URL.</returns>
        public static bool CheckConnection(String URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if can fly kite.
        /// </summary>
        /// <param name="weatherCondition">list of weather conditions from API response.</param>
        /// <param name="windspeed">API response wind speed.</param>
        /// <returns>returns true if it's not raining, and wind speed is over 15. </returns>
        public static bool CanFlyKite(List<string> weatherCondition, string windspeed)
        {
            bool isRaining = IsItRaining(weatherCondition);
            bool _canFlyKite = false;
            if (isRaining == true && Convert.ToInt32(windspeed) < 15)
            {
                Console.WriteLine("No, It is raining and windspeed {0}.", windspeed);
            }
            else if (isRaining == true)
            {
                Console.WriteLine("No, It is raining!");
            }
            else if (Convert.ToInt32(windspeed) < 15)
            {
                Console.WriteLine("No, Windspeed is {0}", windspeed);
            }
            else
            {
                _canFlyKite = true;
            }
            return _canFlyKite;
        }

        /// <summary>
        /// Check if the weather conditions indicate that it is raining.
        /// </summary>
        /// <param name="weatherCondition">list of weather conditions from API response.</param>
        /// <returns>returns true if rain is mentioned otherwise false</returns>
        public static bool IsItRaining(List<string> weatherCondition)
        {
            //Only weather conditions with rain word qualifies as rain weather conditions.
            List<string> rainWeatherConditions = new List<string>() { "Patchy rain possible", "Patchy light rain", "Light rain", "Moderate rain at times",
                "Moderate rain", "Heavy rain at times", "Heavy rain", "Light freezing rain" };
            bool IsRaining = false;
            //Check if ther are any common data between the weather condition and rain weather condition. 
            if (rainWeatherConditions.Intersect(weatherCondition).Any() == true)
            {
                IsRaining = true;
            }
            return IsRaining;
        }


        /// <summary>
        /// List of weather conditions provided by WeatherStackAPI
        /// </summary>
        private List<string> _weatherConditions = new List<string>() {
            "Sunny",
            "Partly cloudy",
            "Cloudy",
            "Overcast",
            "Mist",
            "Patchy rain possible",
            "Patchy snow possible",
            "Patchy sleet possible",
            "Patchy freezing drizzle possible",
            "Thundery outbreaks possible",
            "Blowing snow",
            "Blizzard",
            "Fog",
            "Freezing fog",
            "Patchy light drizzle",
            "Light drizzle",
            "Freezing drizzle",
            "Heavy freezing drizzle",
            "Patchy light rain",
            "Light rain",
            "Moderate rain at times",
            "Moderate rain",
            "Heavy rain at times",
            "Heavy rain",
            "Light freezing rain"
        };
    }
}
