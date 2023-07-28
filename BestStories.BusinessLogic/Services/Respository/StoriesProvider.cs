using BestStories.BusinessLogic.Services.Contracts;
using BestStories.Data.Services.Contracts;
using BestStories.Model;

namespace BestStories.BusinessLogic.Services.Respository
{
    public class StoriesProvider : IStoriesProvider
    {
        private readonly IStoryDataManager _storyDataManager;

        public StoriesProvider(IStoryDataManager storyDataManager)
        {
            _storyDataManager = storyDataManager;
        }
        public async IAsyncEnumerable<BestStory> GetFirstNBestStories(int n)
        {
            foreach (var story in await _storyDataManager
                .GetBestStories()
                .OrderByDescending(o => o.Score)
                .Take(n)
                .ToListAsync())

                yield return story;
        }
    }
}