using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.steps
{
    [Binding]
    public class Hooks
    {
        public RestClient client = new RestClient("http://demostore.gatling.io");
        public RestRequest request;
        public RestResponse response;

        public string token;

        public string urlBase = "http://demostore.gatling.io";
        public string _username = "admin";
        public string _password = "admin";

        [BeforeScenario]
        public void BeforeScenario()
        {
            request = new RestRequest("/api/authenticate", Method.Post);
            request.AddJsonBody(new
            {
                username = "admin",
                password = "admin"
            });
            response = client.ExecutePost(request);

            var jsonObject = JObject.Parse(response.Content);
            token = jsonObject.SelectToken("token").ToString();
        }
    }
}
