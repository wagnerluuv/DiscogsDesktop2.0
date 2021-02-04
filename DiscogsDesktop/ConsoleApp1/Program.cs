using System;
using System.Collections.Generic;
using RestSharp;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string token = "mdplfqERSYCmucgKFnKniXXiEYamTYJnnQkGqEzf";

            string authHeaderName = "Authorization";

            string tokenHeaderValue = $"Discogs token={token}";

            string userIdentityUrl = "oauth/identity";

            string baseUrl = "https://api.discogs.com";

            RestClient client = new RestClient(baseUrl);

            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {authHeaderName, tokenHeaderValue},
                {"Accept-Encoding", "gzip"}
            });

            string result = client.Execute(new RestRequest(userIdentityUrl, Method.GET)).Content;

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}