using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackAPI.APIController
{
    /// <summary>
    /// URL parameters and endpoints collection for future extensibility.
    /// </summary>
    public static class URL
    {
        private static string _newURL = "";
        public enum GetParam{ 
            access_key,
            query,
            callback      
        }

        public enum EndPoint { 
            current,
            historical,
            autocomplete,
            forecast
        }

        public static void SetURL(string APIURL, string access_key, string zipcode)
        {
            _newURL =  APIURL + EndPoint.current + "?" + GetParam.access_key + "=" + access_key + "&" + GetParam.query + "=" + zipcode;
        }

        public static string NewURL { get { return _newURL; } }
    }
}
