using NUnit.Framework;
using System;
using RestSharp;
using System.Net;
using Tests.Services;
using Tests.Configuration;

namespace Tests
{
    /*[TestFixture]
    public class Test
    {     
        [Test]
        public void TestCase()
        {
            // получаем token
            Config.apiKey = Authenticator.GetToken($"{Config.baseUrl}/registration");

            var restClient = new RestClient(Config.baseUrl);
            var request = new RestRequest("/v2/request/1302708", Method.Get);
            request.AddHeader("Authorization", Config.apiKey);

            var responce = restClient.Execute(request);

            Assert.That(responce.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
        }
    }*/
}
