using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherStackLibrary.APIController
{
    /// <summary>
    /// URL parameters and endpoints collection for future extensibility.
    /// </summary>
    public class URL : IURL
    {
        private string _newURL = "";
        private string _baseURL = "";
        private string _zipCode = "";
        private string _APIAssessKey = "";


        public URL(string baseURL, string zipCode, string APIAccessKey)
        {
            this._baseURL = baseURL;
            this._zipCode = zipCode;
            this._APIAssessKey = DecodeAPIAccessKey(APIAccessKey);
        }

        public enum GetParam
        {
            access_key,
            query,
            callback
        }

        public enum EndPoint
        {
            current,
            historical,
            autocomplete,
            forecast
        }

        string IURL.GetCurrentEndPoint()
        {
            return _baseURL + EndPoint.current + "?" + GetParam.access_key + "=" + _APIAssessKey + "&" + GetParam.query + "=" + _zipCode;
        }

        private string DecodeAPIAccessKey(string EncryptedKey)
        {
            byte[] base64EncodedBytes = System.Convert.FromBase64String(EncryptedKey);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
