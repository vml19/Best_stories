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
        public void GetBestStoriesShouldReturnListofStories()
        {
            static async IAsyncEnumerable<BestStory> BestStoriesData()
            {
                yield return new BestStory
                {
                    CommentCount = 100,
                    PostedBy = "Test user",
                    Score = 121,
                    Time = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffzzz"),
                    Title = "Test best story title",
                    Uri = "Test Uri"
                };
                await Task.CompletedTask;
            }

            storiesProviderMock.Setup(t => t.GetBestNStories(1)).Returns(BestStoriesData);

            var bestStoriesExpected = bestStoriesController.Get(1);

            Assert.That(bestStoriesExpected, Is.Not.Null);
            
        }
    }
}