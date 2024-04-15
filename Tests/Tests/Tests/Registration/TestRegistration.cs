using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using Tests.Configuration;
using Tests.Models;
using Tests.Models.Requests;

namespace Tests.Tests.Registration
{
    [TestFixture]
    public class TestRegistration
    {
        [TestCase("login : Test : Test123", HttpStatusCode.OK, "application/json")] 
        public void RegistrationTest(string loginAndPassword, HttpStatusCode httpStatusCode, string contentType)
        {
            // клиент
            var restAuthClient = new RestClient(Config.baseUrl);
            // запрос
            var request = new RestRequest("registration", Method.Post);
            // тело запроса
            request.AddJsonBody<AuthBody>(new AuthBody { devType = "int", pushToken = string.Empty });
            // заголовок с API key
            request.AddHeader("Authorization", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginAndPassword)));
            //ответ
            var response = restAuthClient.Execute(request);

            // множественные проверки
            Assert.Multiple(()=> 
            {   
                // проверка статуса ответа
                Assert.That(response.StatusCode, Is.EqualTo(httpStatusCode));
                // проверка типа контента
                Assert.That(response.ContentType, Is.EqualTo(contentType));
            });


        }
    }
}
