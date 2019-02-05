using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.ApiTests
{
    public class ApiTests : ApiTestsFixture
    {
        [Test]
        public void ApiGetFirstPostTitle()
        {
            var url = ConfigurationManager.AppSettings["ApiBaseUrl"];
            Initialize(url).
                SendGetObject("posts/1").
                    ResponseJson.SelectTokens("title").FirstOrDefault().
                    Should().Equals("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");


            //Request = new RestRequest("posts/1", Method.GET);
            //Response = Client.Get(Request);
            //Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //ResponseJson = JObject.Parse(Response.Content);
            //string title = (string)ResponseJson.SelectTokens("title").FirstOrDefault();
            //StringAssert.AreEqualIgnoringCase(title, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }
    }
}
