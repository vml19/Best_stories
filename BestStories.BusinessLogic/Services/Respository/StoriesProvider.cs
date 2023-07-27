using BestStories.BusinessLogic.Services.Contracts;
using BestStories.Data.Services.Repository;
using BestStories.Model;

namespace BestStories.BusinessLogic.Services.Respository
{
    public class StoriesProvider : IStoriesProvider
    {
        private readonly StoryDataManager _storyDataManager;

        public StoriesProvider(StoryDataManager storyDataManager)
        {
            _storyDataManager = storyDataManager;
        }
        public async IAsyncEnumerable<BestStory> GetFirstNBestStories(int n)
        {
            var allBestStories = await _storyDataManager
                .GetBestStories()
                .OrderByDescending(o=>o.Score)
                .Take(n)
                .ToListAsync();    
            yield return allBestStories.First();
        }
    }
}