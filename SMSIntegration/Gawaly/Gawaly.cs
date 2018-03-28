using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;

namespace SMSIntegration.Gawlay
{
    public class Gawaly
    {
        public static Task SendAsync(string destination, string body)
        {
          var  BaseUrlParameters = "?user=" + ConfigurationManager.AppSettings["Gawaly.user"] + "&pass=" + ConfigurationManager.AppSettings["Gawaly.pass"]+"&to="+ destination + "&message=" + body+ "&from=" + ConfigurationManager.AppSettings["Gawaly.sender"]+ "&sender=" + ConfigurationManager.AppSettings["Gawaly.sender"];
            string Url = ConfigurationManager.AppSettings["Gawaly.url"];
            LogManager.GetLogger(typeof(Gawaly)).Info("Gawaly request =>" + Url+ BaseUrlParameters);
            HttpClient client = new HttpClient { BaseAddress = new Uri(Url) };
            HttpResponseMessage response = null;
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            var task = client.GetAsync(BaseUrlParameters).ContinueWith((taskwithresponse) =>
            {
                response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                LogManager.GetLogger(typeof(Gawaly)).Info("Gawaly response =>" + jsonString);
                LogManager.GetLogger(typeof(Gawaly)).Info("Gawaly IsSuccessStatusCode =>" + response.IsSuccessStatusCode);
                LogManager.GetLogger(typeof(Gawaly)).Info("Gawaly StatusCode =>" + response.StatusCode);
                jsonString.Wait();
         

            });
            return task;
        }

    }
}
