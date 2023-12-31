using BestStories.BusinessLogic.Services.Contracts;
using BestStories.Controllers;
using BestStories.Model;
using Moq;

namespace BestStories.RestApi.Test
{
    public class BestStoriesControllerTests
    {
        Mock<IStoriesProvider> storiesProviderMock;
        BestStoriesController bestStoriesController;

        [SetUp]
        public void Setup()
        {
            storiesProviderMock = new Mock<IStoriesProvider>();
            bestStoriesController = new BestStoriesController(storiesProviderMock.Object);
        }

        [Test]
        public async Task GetBestStoriesShouldReturnListofStories()
        {
            //Test data
            static async IAsyncEnumerable<BestStory> BestStoriesData()
            {
                yield return new BestStory
                {
                    CommentCount = 123,
                    PostedBy = "Test user1",
                    Score = 655,
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

            int noOfBestStoriesRequested = 3;

            storiesProviderMock.Setup(t => t.GetBestNStories(noOfBestStoriesRequested)).Returns(BestStoriesData);

            var actualBestStoriesReturned = new List<BestStory>();
            await foreach (var story in bestStoriesController.Get(noOfBestStoriesRequested))
            {
                actualBestStoriesReturned.Add(story);
            }

            Assert.That(noOfBestStoriesRequested, Is.EqualTo(actualBestStoriesReturned.Count));
        }
    }
}