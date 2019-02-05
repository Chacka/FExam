using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using Serilog.Events;

namespace FinalExam.ApiTests
{
    using _ = ApiTestsFixture;

    public class ApiTestsFixture
    {
        public static RestClient Client { get; set; }
        public RestRequest Request { get; set; }
        public IRestResponse Response { get; set; }
        public JObject ResponseJson { get; set; }
        public JArray ResponseJArray { get; set; }

        public ApiTestsFixture()
        {

        }

        public _ Initialize(string baseUrl)
        {
            Client = new RestClient
            {
                BaseUrl = new System.Uri(baseUrl),
                Timeout = System.Convert.ToInt32(System.TimeSpan.FromMinutes(3).TotalMilliseconds)
                
            };
            return this;
        }

        public _ SendGetObject(string ep)
        {
            Request = new RestRequest(ep, Method.GET);
            Response = Client.Get(Request);
            ResponseJson = JObject.Parse(Response.Content);
            Client.ExecuteAsync(Request, Response => {
                //WriteLine(Response.Content);
            });
            return this;
        }

        public _ SendGetArray(string ep)
        {
            Request = new RestRequest(ep, Method.GET);
            Response = Client.Get(Request);
            ResponseJArray = JArray.Parse(Response.Content);
            return this;
        }
    }
}
