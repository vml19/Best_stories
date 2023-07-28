using BestStories.Channel.Services.Contracts;
using BestStories.Model;

namespace BestStories.Channel.Services.Respository
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async IAsyncEnumerable<int> GetBestStoriesAsync(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<int>>();

                foreach (var item in result)
                {
                    yield return item;
                }
            }
        }

        public async IAsyncEnumerable<Story> GetStoryAsync(string path)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                yield return await response.Content.ReadAsAsync<Story>();
            }
        }
    }
}
