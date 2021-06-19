using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WeatherStackLibrary.ZipCode
{
    public class ZipCodeValidator
    {
        /// <summary>
        /// OWASP A1:2017-Injection
        /// White Listing 
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public static bool Validate(string zipCode)
        {
            if (string.IsNullOrEmpty(zipCode) == true)
            {
                Console.WriteLine(Environment.NewLine + "Zipcode is empty!" + Environment.NewLine);
                return false;
            }

            if (Regex.IsMatch(zipCode, @"^\d{5}?$") != true)
            {
                Console.WriteLine(Environment.NewLine + "Zipcode does not match USZipCode!" + Environment.NewLine);
                return false;
            }

            return true;
        }
    }
}
