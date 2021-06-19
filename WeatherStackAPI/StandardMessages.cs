using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackAPI
{
    public class StandardMessages
    {
        public static void EnterZipCodeMessage()
        {
            Console.WriteLine("Enter US Zipcode:");
        }

        public static void NoInternetMessage()
        {
            Console.WriteLine("Please check connection and restart application.");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }

        public static ConsoleKey TerminateMessage()
        {
            ConsoleKeyInfo terminateKey;

            Console.WriteLine("Press Escape to end program or press any key to show question again.");
            terminateKey = Console.ReadKey(true);
            Console.WriteLine(Environment.NewLine);

            return terminateKey.Key;
        }
    }
}
