using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApi.Application.DataServiceClients
{
    public class DataBaseServiceClient : IDataBaseServiceClient
    {
        public IHttpClientFactory clientFactory;

        public DataBaseServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }


        public async Task<IEnumerable<string>> GetTestsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://localhost:44351/doctors");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>(responseStream, options);

        }
    }
}
