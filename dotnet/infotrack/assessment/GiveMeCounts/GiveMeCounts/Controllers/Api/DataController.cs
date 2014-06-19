using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using GiveMeCounts.Models;
using GiveMeCounts.Services;
using Ninject;

namespace GiveMeCounts.Controllers.Api
{
    public class DataController : BaseController
    {
        [Inject]
        public ICounterService CounterService { get; set; }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("GetCount")]
        public HttpResponseMessage GetCount(GetCountRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(model.url + "/search?num=100&q=" + HttpUtility.UrlEncode(model.keywords));
                    request.Method = "GET";
                    String test = String.Empty;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        test = reader.ReadToEnd();
                        File.WriteAllText(@"F:\dev\goolg_result.html", test);
                        reader.Close();
                        dataStream.Close();
                        string pattern = "\\<h3 class=\"r\"\\>\\<a href=\"/url\\?q=http://www\\.infotrack\\.com\\.au";
                        int count = CountStringOccurrences(test, pattern);
                        return CreateSucccessResponse(count);// Request.CreateResponse<object>(HttpStatusCode.OK, new { success = true, data = count });
                    }
                }
                else
                {
                    //return Request.CreateResponse<object>(HttpStatusCode.OK, new { success = false, message = "request parameter is invalid" });
                    return CreateErrorResponse("request parameter is invalid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new ApplicationException("Internal server error"));
                // TODO: log exception here...
            }
            
        }

        private HttpResponseMessage CreateSucccessResponse(object data)
        {
            return Request.CreateResponse<object>(HttpStatusCode.OK,
                new
                {
                    data = data,
                    success = true
                }
            );
        }

        private HttpResponseMessage CreateErrorResponse(string message)
        {
            return Request.CreateResponse<object>(HttpStatusCode.OK,
                new
                {
                    success = false,
                    message = message
                }
            );
        }
        public static int CountStringOccurrences(string text, string pattern)
        {

            return Regex.Matches(text, pattern).Count;

            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}
