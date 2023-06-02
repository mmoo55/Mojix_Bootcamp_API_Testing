using APITestingMojixBootcamp.request;
using Gherkin;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace APITestingMojixBootcamp.steps
{
    [Binding]
    public class ProductStepDefinitions : Hooks
    {
        [Given(@"^I navigate to the url$")]
        public void GivenINavigateToTheUrl()
        {
            client = new RestClient(urlBase);
        }

        [Given(@"^I have a new (GET|POST|PUT) request to '([^']*)'$")]
        public void GivenIHaveANewRequestTo(string method, string endpoint)
        {
            request = new RestRequest(endpoint, RequestMethodFactory.CreateRequest(method));
        }

        [When(@"I send a request")]
        public void WhenISendARequest()
        {
            response = client.Execute(request);
        }

        [Then(@"I expect a valid code response")]
        public void ThenIExpectAValidCodeResponse()
        {
            Assert.That(response.StatusCode,
                Is.EqualTo(HttpStatusCode.OK), "The response code is not as expected");
        }

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            request.AddUrlSegment("id", p0);
        }

        [Then(@"I expect that is same id (.*)")]
        public void ThenIExpectThatIsSameId(string p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("id").ToString();
            Assert.That(result, Is.EqualTo(p0), "Id is not correct");
        }

        [Given(@"I send authorize token")]
        public void GivenISendAuthorizeToken()
        {
            request.AddHeader("Authorization", $"Bearer {token}");
        }

        [Given(@"I send the following data: ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", (.*), (.*)")]
        public void GivenISendTheFollowingData(string p0, string p1, string p2, decimal p3, int p4)
        {
            request.AddBody(new
            {
                name = p0,
                description = p1,
                image = p2,
                price = p3,
                categoryId = p4
            });
        }

        [Then(@"I expect that is same price (.*)")]
        public void ThenIExpectThatIsSamePrice(string p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("price").ToString();
            Assert.That(result, Is.EqualTo(p0), "price is not correct");
        }

        [Then(@"I expect a list of product")]
        public void ThenIExpectAListOfProduct()
        {
            var jsonArray = JArray.Parse(response.Content);
            Assert.IsTrue(jsonArray.Count > 0, "List has not values");
        }

        [Then(@"I expect that is same name ""([^""]*)""")]
        public void ThenIExpectThatIsSameName(string p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("name").ToString();
            Assert.That(result, Is.EqualTo(p0), "Name is not correct");
        }
    }
}
