using BestStories.Channel.Services.Contracts;
using BestStories.Data.Services.Contracts;
using BestStories.Model;

namespace BestStories.Data.Services.Repository
{
    public class StoryDataManager : IStoryDataManager
    {
        private readonly IRestClient _externalDataManager;

        public StoryDataManager(IRestClient externalDataManager)
        {
            _externalDataManager = externalDataManager;
        }
        public async IAsyncEnumerable<BestStory> GetBestStories()
        {
            await foreach (var bestStoryId in _externalDataManager.GetBestStories())
            {
                var bestStory = await _externalDataManager.GetStory(bestStoryId);

                yield return new BestStory
                {
                    CommentCount = bestStory.CommentCount,
                    PostedBy = bestStory.PostedBy,
                    Score = bestStory.Score,
                    Time = DateTime.UnixEpoch.AddSeconds(bestStory.Time).ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"),
                    Title = bestStory.Title,
                    Uri = bestStory.Uri
                };
            }
        }
    }
}