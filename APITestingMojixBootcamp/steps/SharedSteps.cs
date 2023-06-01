using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp
{
    [Binding]
    public class ProductStepDefinitions
    {
        [Given(@"def token = '([^']*)'")]
        public void GivenDefToken(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have a new ""([^""]*)"" request")]
        public void GivenIHaveANewRequest(string get)
        {
            throw new PendingStepException();
        }

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I send a Get request")]
        public void WhenISendAGetRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"I expect a valid code response")]
        public void ThenIExpectAValidCodeResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"I expect that is same id (.*)")]
        public void ThenIExpectThatIsSameId(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have a new Put request")]
        public void GivenIHaveANewPutRequest()
        {
            throw new PendingStepException();
        }

        [Given(@"I send authorize token")]
        public void GivenISendAuthorizeToken()
        {
            throw new PendingStepException();
        }

        [Given(@"I send following data")]
        public void GivenISendFollowingData(string multilineText)
        {
            throw new PendingStepException();
        }

        [When(@"I send a Put request")]
        public void WhenISendAPutRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"I expect that is same price ""([^""]*)""")]
        public void ThenIExpectThatIsSamePrice(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have a new Post request")]
        public void GivenIHaveANewPostRequest()
        {
            throw new PendingStepException();
        }

        [When(@"I send a Post request")]
        public void WhenISendAPostRequest()
        {
            throw new PendingStepException();
        }

        [Then(@"I expect that is same name ""([^""]*)""")]
        public void ThenIExpectThatIsSameName(string p0)
        {
            throw new PendingStepException();
        }
    }
}
