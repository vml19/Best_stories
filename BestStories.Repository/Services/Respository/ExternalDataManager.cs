using BestStories.Channel.Services.Contracts;
using BestStories.Model;

namespace BestStories.Repository.Services.Respository
{
    public class ExternalDataManager : IExternalDataManager
    {
        private readonly IApiClient _apiClient;

        public ExternalDataManager(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<IEnumerable<int>> GetBestStories()
        {
            return await _apiClient.GetBestStoriesAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
        }

        public async Task<Story> GetStory(int id)
        {
            return await _apiClient.GetStoryAsync("https://hacker-news.firebaseio.com/v0/item/"+ id + ".json");
        }
    }
}