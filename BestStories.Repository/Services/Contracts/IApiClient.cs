using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IApiClient
    {
        IAsyncEnumerable<int> GetBestStoriesAsync(string path);
        IAsyncEnumerable<Story> GetStoryAsync(string path);
    }
}
