using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using TP3.Domain;

namespace TP3.CMD
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                var client = new RestClient("https://localhost:44375/");

                var requestToken = new RestRequest("api/authenticate/token", Method.POST);
                requestToken.AddJsonBody(JsonConvert.SerializeObject(new
                {
                    Email = "evs.lopes@gmail.com",
                    Nome = "Elvis"
                }));

                var token = client.Post<String>(requestToken);
                JObject rss = JObject.Parse(token.Content);
                string rssToken = (string)rss["token"];

                var request = new RestRequest("api/amigo", Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + rssToken);

                var response = client.Get<List<Amigo>>(request);
                Console.WriteLine($"Token: {rssToken}\n" +
                    $"\nStatus: {response.StatusCode} " +
                    $"\nValidação: {response.IsSuccessful}");

                Console.WriteLine(response.Data);

                
            }
        }
    }

}
