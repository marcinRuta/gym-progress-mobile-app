using ClientApi.Application.Commands;
using ClientApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<Response> AddUserDetails(AddUserDetailsCommand details, UserCredential credentials)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                Constants.dataBaseAddress + $"addUserDetails");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("username", credentials.Username);
            request.Headers.Add("password", credentials.Password);
            var body = JsonSerializer.Serialize(details);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<Response>(responseStream, options);

        }

        public async Task<UserDetails> GetUserDetails(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
               Constants.dataBaseAddress + $"UserDetails");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("username", username);
            request.Headers.Add("password", password);

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<UserDetails>(responseStream, options);
        }

        public async Task<Response> LoginUser(AddUserCredentialCommand credential)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                Constants.dataBaseAddress + $"usernamePasswordConfimation");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("username", credential.Username);
            request.Headers.Add("password", credential.Password);

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<Response>(responseStream, options);
        
        }

        public async Task<Response> RegisterUser(AddUserCredentialCommand credential)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                 Constants.dataBaseAddress + $"registerUser");

            request.Headers.Add("Accept", "application/json");
            var body = JsonSerializer.Serialize(credential);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await JsonSerializer.DeserializeAsync<Response>(responseStream, options);
        }
    }
}
