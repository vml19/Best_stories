using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IExternalDataManager
    {
        IAsyncEnumerable<int> GetBestStories();
        IAsyncEnumerable<Story> GetStory(int id);
    }
}
