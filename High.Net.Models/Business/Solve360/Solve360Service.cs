using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Configuration;

namespace High.Net.Models.Business.Solve360
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    
    public class Solve360Client
    {
        private string EndPoint = "https://secure.solve360.com";
        private string ContentType = "application/xml";

        private string username = ConfigurationManager.AppSettings["Solve360_Username"];
        private string password = ConfigurationManager.AppSettings["Solve360_Token"];

        public Solve360Client()
        {
        }
        
        public XDocument MakeRequest(string itemType, HttpVerb method, HttpStatusCode httpStatusCode, string postData = null)
        {
            XDocument xDocument = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(EndPoint + itemType);

                request.Method = method.ToString();
                request.ContentLength = 0;
                request.ContentType = ContentType;

                //authientication          
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
                request.Headers.Add("Authorization", "Basic " + encoded);

                if (!string.IsNullOrEmpty(postData) && method == HttpVerb.POST || method == HttpVerb.PUT)
                {
                    var encoding = new UTF8Encoding();
                    var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(postData);
                    request.ContentLength = bytes.Length;

                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseValue = string.Empty;

                    if (response.StatusCode != httpStatusCode)
                    {
                        var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                xDocument = XDocument.Load(reader);
                            }
                    }

                 
                }
            }
            catch { }
            return xDocument;
        }
    } 
}