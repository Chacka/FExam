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
            GetPosts().
                First().Title.Should().Equals("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }

        [Test]
        public void ApiGetAllPosts()
        {
            GetPosts().Count().Should().Equals(100);
        }

        [Test]
        public void ApiCreatePost()
        {
            AddPost(out string guid);
        }
    }
}
