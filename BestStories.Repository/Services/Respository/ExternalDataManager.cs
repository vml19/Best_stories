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
        public async IAsyncEnumerable<int> GetBestStories()
        {
            await foreach (var bestStoryId in _apiClient.GetBestStoriesAsync("https://hacker-news.firebaseio.com/v0/beststories.json"))
            {
                yield return bestStoryId;
            }
        }

        public async IAsyncEnumerable<Story> GetStory(int id)
        {
            await foreach (var story in _apiClient.GetStoryAsync("https://hacker-news.firebaseio.com/v0/item/" + id + ".json"))
            {
                yield return story;
            }
        }
    }
}