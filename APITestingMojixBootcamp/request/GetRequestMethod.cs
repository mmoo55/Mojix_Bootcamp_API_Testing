using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public class GetRequestMethod : IRestRequestMethod
    {
        public RestRequest CreateRequest()
        {
            return new RestRequest(Method.GET);
        }
    }
}