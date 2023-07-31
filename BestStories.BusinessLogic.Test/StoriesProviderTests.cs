using BestStories.BusinessLogic.Services.Respository;
using BestStories.Data.Services.Contracts;
using BestStories.Model;
using Moq;

namespace BestStories.BusinessLogic.Test
{
    public class StoriesProviderTests
    {
        Mock<IStoryDataManager> storyDataManagerMock;
        StoriesProvider storiesProvider;

        [SetUp]
        public void Setup()
        {
            storyDataManagerMock = new Mock<IStoryDataManager>();
            storiesProvider = new StoriesProvider(storyDataManagerMock.Object);
        }

        [Test]
        public async Task GetBestNStoriesShouldReturnListOfNStories()
        {
            //Test data
            static async IAsyncEnumerable<BestStory> StoriesData()
            {
                yield return new BestStory
                {
                    CommentCount = 123,
                    PostedBy = "Test user1",
                    Score = 55,
                    Time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"),
                    Title = "Test best story title1",
                    Uri = "Test Uri1"
                };
                yield return new BestStory
                {
                    CommentCount = 45,
                    PostedBy = "Test user2",
                    Score = 233,
                    Time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"),
                    Title = "Test best story title2",
                    Uri = "Test Uri2"
                };
                yield return new BestStory
                {
                    CommentCount = 67,
                    PostedBy = "Test user3",
                    Score = 121,
                    Time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"),
                    Title = "Test best story title3",
                    Uri = "Test Uri3"
                };
                await Task.CompletedTask;
            }

            int noOfBestStoriesRequested = 2;

            storyDataManagerMock.Setup(t => t.GetBestStories()).Returns(StoriesData);

            var bestStoriesActual = new List<BestStory>();
            await foreach (var story in storiesProvider.GetBestNStories(noOfBestStoriesRequested))
            {
                bestStoriesActual.Add(story);
            }

            Assert.Multiple(() =>
            {
                Assert.That(noOfBestStoriesRequested, Is.EqualTo(bestStoriesActual.Count));

                Assert.That(actual: StoriesData()
                    .OrderByDescending(e => e.Score).Take(noOfBestStoriesRequested).FirstAsync().Result.Score,
                    Is.EqualTo(bestStoriesActual.First().Score));
            });
        }
    }
}