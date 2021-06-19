using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WeatherStackLibrary.APIController
{
    public class ConnectionProvider
    {
        /// <summary>
        /// Check internet connection
        /// </summary>
        /// <param name="URL">URL parameter to be checked.</param>
        /// <returns>returns true if can connect to URL.</returns>
        public static bool CheckConnection(String URL, ILogger log)
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
            catch(Exception ee)
            {
                log.Log(ee.StackTrace);
                return false;
            }
        }
    }
}
