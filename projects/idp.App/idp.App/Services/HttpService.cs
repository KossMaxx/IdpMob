using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Autofac;
using idp.App.Models;
using idp.App.Services.Contracts;
using idp.Dal.Repository.Contracts;
using Xamarin.Forms;

namespace idp.App.Services
{
    public class HttpService : IHttpService
    {
        private string _defaultUrl;
        private readonly ITokenRepository _tokenRepository;

        public event Action UnauthorizedRequest;

        public HttpService()
        {
            _defaultUrl = Constants.DefaultApiUrl;
            _tokenRepository = App.Container.Resolve<ITokenRepository>();
        }

        public async Task<string> GetAsync(string url)
        {
            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();

            using (var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(Constants.BigRequestTimeout)
            })
            {
                var token = _tokenRepository.Get();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.GetAsync($"{_defaultUrl}{url}");

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    UnauthorizedRequest?.Invoke();
                }

                var responseStr = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    responseStr = await response.Content.ReadAsStringAsync();
                }

                return responseStr;
            }
        }

        public string Get(string url)
        {
            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();

            using (var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(Constants.BigRequestTimeout)
            })
            {
                var token = _tokenRepository.Get();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = httpClient.GetAsync($"{_defaultUrl}{url}").Result;

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    UnauthorizedRequest?.Invoke();
                }

                var responseStr = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    responseStr = response.Content.ReadAsStringAsync().Result;
                }

                return responseStr;
            }
        }

        public string Post(string url, string jsonData)
        {
            var token = _tokenRepository.Get();

            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();

            using (var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(Constants.BigRequestTimeout)
            })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync($"{_defaultUrl}{url}", content).Result;

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    UnauthorizedRequest?.Invoke();
                }

                var responseStr = string.Empty;

                if (response.IsSuccessStatusCode)
                {
                    responseStr = response.Content.ReadAsStringAsync().Result;
                }

                return responseStr;
            }
        }

        public async Task<string> PostAsync(string url, string jsonData)
        {
            var token = _tokenRepository.Get();

            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();

            using (var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(Constants.BigRequestTimeout)
            })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpContent content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync($"{_defaultUrl}{url}", content);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    UnauthorizedRequest?.Invoke();
                }

                var responseStr = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    responseStr = await response.Content.ReadAsStringAsync();
                }

                return responseStr;
            }
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, (_defaultUrl + "token"))
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();

            var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(Constants.SmallRequestTimeout)
            };
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task CheckConnectionWithServerAsync()
        {
            var handler = DependencyService.Get<IHTTPClientHandlerCreationService>().GetInsecureHandler();
            handler.UseProxy = false;

            var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
            HttpResponseMessage response = await httpClient.GetAsync($"{_defaultUrl}check-connection");
            if (response.IsSuccessStatusCode)
            {
                Constants.InternetAccess = true;
            }
        }
    }
}
