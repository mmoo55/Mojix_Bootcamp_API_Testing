using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public class PutRequestMethod : IRestRequestMethod
    {
        public RestRequest CreateRequest()
        {
            return new RestRequest(Method.PUT);
        }
    }
}