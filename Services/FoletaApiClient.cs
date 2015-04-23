using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Foleta.API.NET45
{
    /// <summary>
    /// FoletaApiClient.
    /// Using <see cref="HttpClient"/> from Microsoft.AspNet.WebApi.Client.
    /// </summary>
    public class FoletaApiClient
    {
        /// <summary>
        /// The base address
        /// </summary>
        private readonly string _apiAddress;


        /// <summary>
        /// The base address
        /// </summary>
        private readonly string _apiKey;


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiAddress"></param>
        /// <param name="apiKey"></param>
        public FoletaApiClient(string apiAddress, string apiKey)
        {
            _apiAddress = apiAddress;
            _apiKey = apiKey;
        }


        /// <summary>
        /// GetAsync
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiAddress);
                client.DefaultRequestHeaders.Add("X-Foleta-ApiKey", _apiKey);

                HttpResponseMessage response = client.GetAsync(url).Result;
                return await response.Content.ReadAsAsync<TResponse>();
            }
        }

    }
}
