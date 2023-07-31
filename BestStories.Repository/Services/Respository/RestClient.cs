using BestStories.Channel.Services.Contracts;
using BestStories.Model;
using System.Text.Json;

namespace BestStories.Repository.Services.Respository
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://hacker-news.firebaseio.com/v0/";

        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async IAsyncEnumerable<int> GetBestStories()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/beststories.json");
            if (response.IsSuccessStatusCode)
            {
                var bestStoriesIdsStream = await response.Content.ReadAsStreamAsync();
                IAsyncEnumerable<int> bestStoriesIds = JsonSerializer.DeserializeAsyncEnumerable<int>(bestStoriesIdsStream);

                await foreach (int bestStoriesId in bestStoriesIds)
                    yield return bestStoriesId;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Story> GetStory(int id)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}item/" + id + ".json");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<Story>();
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}