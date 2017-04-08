using System;
using System.IO;
using System.Net;

namespace ChDCStatMenusLibrary
{
    public class NetworkInfo
    {
        public static string GetPublicIP()
        {
            try
            {
                string uri = "http://ip.bjango.com/";
                HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
                request.Method = "GET";
                request.ProtocolVersion = new Version(1, 1);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
