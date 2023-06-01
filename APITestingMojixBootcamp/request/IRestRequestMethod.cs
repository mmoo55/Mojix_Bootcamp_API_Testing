using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public interface IRestRequestMethod
    {
        RestRequest CreateRequest();
    }
}