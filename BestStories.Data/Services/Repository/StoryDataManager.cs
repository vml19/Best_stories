using BestStories.Channel.Services.Contracts;
using BestStories.Data.Services.Contracts;
using BestStories.Model;
using System.Collections.Generic;

namespace BestStories.Data.Services.Repository
{
    public class StoryDataManager : IStoryDataManager
    {
        private readonly IExternalDataManager _externalDataManager;

        public StoryDataManager(IExternalDataManager externalDataManager)
        {
            _externalDataManager = externalDataManager;
        }
        public async IAsyncEnumerable<BestStory> GetBestStories()
        {
            foreach (var bestStoryId in await _externalDataManager.GetBestStories())
            {
                var bestStory = await _externalDataManager.GetStory(bestStoryId);

                yield return new BestStory
                {
                    CommentCount = bestStory.descendants,
                    PostedBy = bestStory.by,
                    Score = bestStory.score,
                    Time = bestStory.time,
                    Title = bestStory.title,
                    Uri = bestStory.url
                };
            }
        }
    }
}