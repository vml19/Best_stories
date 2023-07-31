using BestStories.Channel.Services.Contracts;
using BestStories.Data.Services.Repository;
using BestStories.Model;
using Moq;

namespace BestStories.Data.Test
{
    public class StoryDataManagerTests
    {
        Mock<IRestClient> restClientMock;
        StoryDataManager storyDataManager;

        [SetUp]
        public void Setup()
        {
            restClientMock = new Mock<IRestClient>();
            storyDataManager = new StoryDataManager(restClientMock.Object);
        }

        [Test]
        public async Task GetBestStoriesReturnListOfStories()
        {
            //Test data            
            static async IAsyncEnumerable<int> StoryIdsData()
            {
                yield return 12;
                yield return 23;
                yield return 22;
                await Task.CompletedTask;
            }

            static Task<Story> StoryData()
            {
                return Task.FromResult(new Story
                {
                    CommentCount = 123,
                    PostedBy = "Test user1",
                    Score = 55,
                    Title = "Test best story title1",
                    Uri = "Test Uri1"
                });
            }

            restClientMock.Setup(t => t.GetBestStoryIds()).Returns(StoryIdsData);            
            restClientMock.Setup(t => t.GetStory(It.IsAny<int>())).Returns(StoryData);

            var actualStoriesReceived = new List<BestStory>();
            await foreach (var story in storyDataManager.GetBestStories())
            {
                actualStoriesReceived.Add(story);
            }

            Assert.Multiple(async () =>
            {
                Assert.That(await StoryIdsData().CountAsync(), Is.EqualTo(actualStoriesReceived.Count));

                Assert.That(actualStoriesReceived[0], Is.InstanceOf<BestStory>());
            });
        }
    }
}