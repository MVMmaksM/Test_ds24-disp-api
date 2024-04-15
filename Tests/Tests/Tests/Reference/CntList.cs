using System;
using NUnit.Framework;
using Tests.Configuration;
using Tests.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.IO;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using Tests.Models.Responces;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Tests.Tests.Reference
{
    [TestFixture]
    public class CntList
    {
        private string token = string.Empty;
             
        [SetUp]
        public void SetToken() 
        {
            if (string.IsNullOrWhiteSpace(token))
                token = Authenticator.GetToken($"{Config.baseUrl}/registration");
        }

        [TestCase(HttpStatusCode.OK, "/v2/ref/cnt_list","application/json", 13521)]      
        public void CntListTest(HttpStatusCode httpStatusCode, string resource, string contentType, int cntId) 
        {
            var restClient = new RestClient(Config.baseUrl);
            var request = new RestRequest(resource, Method.Get)
                         .AddHeader("Authorization", token);

            var responce = restClient.Execute(request);

            string schemaJson = @"{
                                      'description': 'A person',
                                      'type': 'array',
                                      'items':
                                        {   'type': 'object',
                                            'required': true,
                                            'properties':
                                              {
                                                'cnt': {'type':'string'},
                                                'cnt_id': {'type':'number'},
                                                'account_id': {'type':'number'}, 
                                                'callback_phone': {'type':['string', 'null']},
                                                'support_phone': {'type':['string', 'null']},
                                              }
                                        }
                                    }";           

            List<EntityCntList> p = JsonConvert.DeserializeObject<List<EntityCntList>>(responce.Content);

            JSchema schema = JSchema.Parse(schemaJson);
            JArray entities = JArray.Parse(responce.Content);
                      
            var isValidSchema = entities.IsValid(schema);
            var isEqualCntId = p.Any(re => re.CntId == cntId);           

            Assert.Multiple(()=> 
            {
                // статус код
                Assert.That(responce.StatusCode, Is.EqualTo(httpStatusCode));
                // contetn type
                Assert.That(responce.ContentType, Is.EqualTo(contentType));
                // schema
                Assert.That(isValidSchema, Is.EqualTo(true));
                // cnt_id
                Assert.That(isEqualCntId, Is.EqualTo(true));
            });
        }
    }
}
