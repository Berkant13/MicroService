using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformServices.Dtos;

namespace PlatformServices.SynDataServices.HTTP
 {
    public class HttpComandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpComandDataClient(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient=httpClient;
            _configuration=configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent= new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");
            var response= await _httpClient.PostAsync($"{_configuration["CommandService"]}",httpContent);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("NOT OK");
            }
        }
    }
}