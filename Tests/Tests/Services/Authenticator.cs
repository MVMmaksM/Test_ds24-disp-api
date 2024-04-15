using System;
using RestSharp;
using Newtonsoft.Json;
using Tests.Models;
using Tests.Models.Requests;
using System.IO;

namespace Tests.Services
{
    public class Authenticator
    {
        private static string Registration(string urlAuthentication) 
        {
            // клиент
            var restAuthClient = new RestClient(urlAuthentication);
            // запрос
            var request = new RestRequest();
            // тело запроса
            request.AddJsonBody<AuthBody>(new AuthBody { devType = "int", pushToken= string.Empty});
            // заголовок с API key
            request.AddHeader("Authorization", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("login : dev : 123")));

            //ответ
            var response = restAuthClient.ExecutePost(request);
            // конвертим в объект
            var responceData = JsonConvert.DeserializeObject<AuthModel>(response.Content);

            //возвращаем токен сконвертированный в base64
            var tokenBase64 =  Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(responceData.Token));

            return tokenBase64;
        }

        public static string GetToken(string urlAuthentication) 
        {
            var token = File.ReadAllText("./config.txt");

            if (string.IsNullOrWhiteSpace(token)) 
            {
                token = Registration(urlAuthentication);
                File.WriteAllText("./config.txt", token);
            }          

            return token;
        }
    }
}
