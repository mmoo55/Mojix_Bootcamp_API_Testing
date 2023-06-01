using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp
{
    [Binding]
    public class ProductStepDefinitions
    {
        RestClient client;
        RestRequest request;
        RestResponse response;

        string token;

        string urlBase = "http://localhost:3000/";
        string username = "admin";
        string password = "admin";

        [Given(@"^I navigate to the url$")]
        public void GivenINavigateToTheUrl()
        {
            client = new RestClient(urlBase);
        }

        [Given(@"I have a new (GET|POST|PUT) request to '(.*)'")]
        public void GivenIHaveANewRequest(string method, string endpoint)
        {
            request = new RestRequest(endpoint, request.RestRequestFactory.CreateRequest(method));
        }

        [When(@"I submit username and password")]
        public void WhenISubmitUsernameAndPassword()
        {
            request.AddJsonBody(new
            {
                username = username,
  		    	password = password
            });
        }

        [When(@"I send a request")]
        public void WhenISendARequest()
        {
            response = restClient.Execute(request);
        }

        [Then(@"I expect a valid code response")]
        public void ThenIExpectAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response code is not as expected");
        }

        [Then(@"{^I expect to receive token$")]
        public void ThenIExpectToReceiveToken()
        {
            var jsonObject = JObject.Parse(response.Content);
            token = jsonObject.SelectToken("token").ToString();
            Assert.That(token, !Is.Empty, "Token is not correct");
        }

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            request.AddUrlSegment("id", 20);
        }

        [Then(@"I expect that is same id (.*)")]
        public void ThenIExpectThatIsSameId(int p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("id").ToString();
            Assert.That(result, Is.EqualTo(p0), "Id is not correct");
        }

        /* [Given(@"I have a new Put request")]
        public void GivenIHaveANewPutRequest()
        {
            throw new PendingStepException();
        } */

        [Given(@"I send authorize token")]
        public void GivenISendAuthorizeToken()
        {
            request.AddHeader("Authorization", $"Bearer {token}");
        }

        [Given(@"I send following data: (.*), (.*), (.*), (.*)")]
        public void GivenISendFollowingData(string name, string description, string image, string price, int categoryId)
        {
            request.AddBody(new
            {
             	name = name,
  		    	description = description,
  		    	image = image,
  		    	price = price,
  		    	categoryId = categoryId
            });
        }

        /* [When(@"I send a Put request")]
        public void WhenISendAPutRequest()
        {
            throw new PendingStepException();
        } */

        /* [Then(@"I expect that is same price ""([^""]*)""")] */
        [Then(@"I expect that is same price (.*)")]
        public void ThenIExpectThatIsSamePrice(string p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("price").ToString();
            Assert.That(result, Is.EqualTo(p0), "price is not correct");
        }

        /* [Given(@"I have a new Post request")]
        public void GivenIHaveANewPostRequest()
        {
            throw new PendingStepException();
        } */

        /* [When(@"I send a Post request")]
        public void WhenISendAPostRequest()
        {
            throw new PendingStepException();
        } */

        /* [Then(@"I expect that is same name ""([^""]*)""")] */
        [Then(@"I expect that is same name (.*)")]
        public void ThenIExpectThatIsSameName(string p0)
        {
            var jsonObject = JObject.Parse(response.Content);
            var result = jsonObject.SelectToken("name").ToString();
            Assert.That(result, Is.EqualTo(p0), "Name is not correct");
        }
    }
}
