using OnlineEducation.UI.Services.TokenServices;
using System.Net.Http.Headers;

namespace OnlineEducation.UI.Helpers
{
    public static class HttpClientInstance
    {
       

        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7029/api/");
            return client;
        }
    }
}
