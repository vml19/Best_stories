using BestStories.Model;

namespace BestStories.BusinessLogic.Services.Contracts
{
    public interface IStoriesProvider
    {
        IAsyncEnumerable<BestStory> GetBestNStories(int n);
    }
}
