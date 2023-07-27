using BestStories.Channel.Services.Contracts;
using BestStories.Model;

namespace BestStories.Channel.Services.Respository
{
    internal class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<int>> GetBestStoriesAsync(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<int>>();
            }
            return null;
        }

        public async Task<Story> GetStoryAsync(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Story>();
            }
            return null;
        }
    }
}
