using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Twitzer.Core.Models;

namespace Twitzer.Core
{
    public abstract class Request
    {
        protected async Task<T> RunAsync<T>(string uriString)
        {
            if(string.IsNullOrWhiteSpace(uriString))
                throw new ArgumentNullException(nameof(uriString));

            Uri uri;
            if(!Uri.TryCreate(uriString, UriKind.Absolute, out uri))
                throw new ArgumentException($"Uri: {uriString} is invalid", nameof(uriString));

            using (var httpClient = new HttpClient())
            {
                var stringResponse = await httpClient.GetStringAsync(uri);
                Debug.WriteLine($"Response: {stringResponse}");
                return JsonConvert.DeserializeObject<T>(stringResponse);
            }
        }
    }

    public class TwitzerRequest : Request
    {
        const string TwitzerEndpoint = "http://176.58.126.236/twitzer/";

        public async Task<IEnumerable<Twitz>> RunAsync()
        {
            return await RunAsync<IEnumerable<Twitz>>(TwitzerEndpoint);
        }
    }
}
