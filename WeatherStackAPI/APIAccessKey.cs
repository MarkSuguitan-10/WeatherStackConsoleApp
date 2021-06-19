using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackUI
{
    public class APIAccessKeyConfig
    {
        /// <summary>
        /// API Access Key
        /// A3:2017-Sensitive Data Exposure. using .net core secrets to hide API Key
        /// </summary>
        string APIAccessKey { get; set; }
    }
}
