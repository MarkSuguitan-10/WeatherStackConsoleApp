using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackLibrary
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Simulate Owasp: A10:2017-Insufficient Logging & Monitoring
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            Console.WriteLine("Simulating logging function: " + Environment.NewLine + message);
        }
    }
}
