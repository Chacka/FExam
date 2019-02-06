using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using Serilog.Events;
using System.Configuration;
using Newtonsoft.Json;
using FinalExam.ApiTests.Models;
using System.Collections.Generic;
using System;
using FluentAssertions;

namespace FinalExam.ApiTests
{
    using _ = ApiTestsFixture;

    public class ApiTestsFixture
    {
        public static RestClient Client { get; set; }
        public RestRequest Request { get; set; }
        public IRestResponse Response { get; set; }
        public JObject ResponseJson { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            Client = new RestClient
            {
                BaseUrl = new System.Uri(baseUrl),
                Timeout = System.Convert.ToInt32(System.TimeSpan.FromMinutes(3).TotalMilliseconds)
            };
        }

        [OneTimeTearDown]
        public void Clean()
        {
        }

        public IEnumerable<Post> GetPosts()
        {
            Request = new RestRequest("posts", Method.GET);
            Response = Client.Get(Request);
            Response.StatusCode.Should().Equals(HttpStatusCode.OK);
            var posts =  JsonConvert.DeserializeObject<Post[]>(Response.Content).ToList();
            return posts;
        }

        public void AddPost(out string guid)
        {
            guid = Guid.NewGuid().ToString();
            
            var post = new Post {
                Body = "AT Body" + guid,
                Title = "AT Title " + guid,
                UserID = "0" };

            var requestBody = JsonConvert.SerializeObject(post);

            Request = new RestRequest("posts", Method.POST);
            Request.AddJsonBody(requestBody);
            Request.AddHeader("Content-type", "application/json; charset=UTF-8");

            Response = Client.Post(Request);
            Response.StatusCode.Should().Equals(HttpStatusCode.Created);
        }
    }
}
