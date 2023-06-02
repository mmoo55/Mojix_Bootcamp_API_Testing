using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APITestingMojixBootcamp.request
{
    public class RequestMethodFactory
    {
        public static Method CreateRequest(string method)
        {
            Method requestMethod;

            switch (method.ToUpperInvariant())
            {
                case "GET":
                    requestMethod = Method.Get;
                    break;
                case "POST":
                    requestMethod = Method.Post;
                    break;
                case "PUT":
                    requestMethod = Method.Put;
                    break;
                default:
                    throw new ArgumentException($"HTTP method not supported: {method}");
            }

            return requestMethod;
        }
    }
}