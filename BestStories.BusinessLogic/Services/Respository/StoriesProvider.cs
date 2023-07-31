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
        public async IAsyncEnumerable<BestStory> GetBestNStories(int n)
        {
            var bestStories = _storyDataManager
                .GetBestStories()
                .OrderByDescending(e => e.Score)
                .Take(n)
                .AsAsyncEnumerable();

            await foreach (var story in bestStories)            
                yield return story;
        }
    }
}