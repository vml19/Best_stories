using BestStories.Model;

namespace BestStories.Data.Services.Contracts
{
    public interface IStoryDataManager
    {
        IAsyncEnumerable<BestStory> GetBestStories();
    }
}
