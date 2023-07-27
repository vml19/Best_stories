using BestStories.Model;

namespace BestStories.Channel.Services.Contracts
{
    public interface IExternalDataManager
    {
        Task<IEnumerable<int>> GetBestStories();
        Task<Story> GetStory(int id);
    }
}
