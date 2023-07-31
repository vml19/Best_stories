using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IRestClient
    {
        IAsyncEnumerable<int> GetBestStories();
        Task<Story> GetStory(int id);
    }
}
