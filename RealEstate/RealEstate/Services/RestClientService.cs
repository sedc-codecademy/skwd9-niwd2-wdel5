using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Essentials;

namespace RealEstate.Services
{
    public class RestClientService
    {
        private readonly Uri BaseUrl = new Uri("http://localhost:5000");
        //private readonly Uri BaseUrl = new Uri("http://10.0.2.2:5000");

        private HttpClient client;

        public RestClientService()
        {
            client = new HttpClient() { BaseAddress = BaseUrl };
        }

        private async Task AddAuthorizationHeader()
        {
            var username = await SecureStorage.GetAsync(PreferencesKeys.UsernameKey);
            var password = await SecureStorage.GetAsync(PreferencesKeys.PasswordKey);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {Base64Encode($"{username}:{password}")}");
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public async Task<string> GetAsync(string route)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                await AddAuthorizationHeader();
                HttpResponseMessage response = await client.GetAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> GetAsync<T>(string route)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(route));
        }

        public async Task<string> PostAsync(string route, object body)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(route, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> PostAsync<T>(string route, object body)
        {
            return JsonConvert.DeserializeObject<T>(await PostAsync(route, body));
        }

        public async Task<string> PatchAsync(string route, object body)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var method = new HttpMethod("PATCH");

                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(method, route)
                {
                    Content = stringContent
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> PatchAsync<T>(string route, object body)
        {
            return JsonConvert.DeserializeObject<T>(await PatchAsync(route, body));
        }

        public async Task<string> DeleteAsync(string route)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                HttpResponseMessage response = await client.DeleteAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> DeleteAsync<T>(string route)
        {
            return JsonConvert.DeserializeObject<T>(await DeleteAsync(route));
        }
    }
}
