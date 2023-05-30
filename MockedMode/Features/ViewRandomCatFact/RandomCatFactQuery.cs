using System.Net.Http.Json;

namespace MockedMode.Features.ViewRandomCatFact
{
    public class RandomCatFactQuery : IRandomCatFactQuery
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RandomCatFactQuery(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<CatFact> Execute()
        {
            HttpClient client = _httpClientFactory.CreateClient();

            return client.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
        }
    }
}
