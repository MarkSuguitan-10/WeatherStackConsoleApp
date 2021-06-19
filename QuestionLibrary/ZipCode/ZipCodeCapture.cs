using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackLibrary.ZipCode
{
    public class ZipCodeCapture
    {
        /// <summary>
        /// Check if input for zipCode is valid.
        /// </summary>
        /// <returns></returns>
        public static string GetZipCode()
        {
            string tempvalue = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                ///Check if pressed is digit, backspace or length of text is over zipcode limit.
                if (key.Key != ConsoleKey.Backspace && tempvalue.Length != 5)
                {
                    bool isDigit = char.IsDigit(key.KeyChar);
                    if (isDigit == true)
                    {
                        tempvalue += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && tempvalue.Length > 0)
                    {
                        tempvalue = tempvalue.Substring(0, (tempvalue.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return tempvalue;
        }
    }
}
