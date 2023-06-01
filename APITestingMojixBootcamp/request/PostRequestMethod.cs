using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public class PostRequestMethod : IRestRequestMethod
    {
        public RestRequest CreateRequest()
        {
            return new RestRequest(Method.POST);
        }
    }
}