using System;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public class RestRequestFactory
    {
        public static IRestRequest CreateRequest(string method)
        {
            IRestRequestMethod requestMethod;

            switch (method.ToUpperInvariant())
            {
                case "GET":
                    requestMethod = new GetRequestMethod();
                    break;
                case "POST":
                    requestMethod = new PostRequestMethod();
                    break;
                case "PUT":
                    requestMethod = new PutRequestMethod();
                    break;
                default:
                    throw new ArgumentException($"HTTP method not supported: {method}");
            }

            return requestMethod.CreateRequest();
        }
    }
}