using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IRestClient
    {
        IAsyncEnumerable<int> GetBestStoryIds();
        Task<Story> GetStory(int id);
    }
}
