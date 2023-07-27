using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IApiClient
    {
        Task<IEnumerable<int>> GetBestStoriesAsync(string path);
        Task<Story> GetStoryAsync(string path);
    }
}
