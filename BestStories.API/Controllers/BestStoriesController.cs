using BestStories.BusinessLogic.Services.Contracts;
using BestStories.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BestStories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestStoriesController : ControllerBase
    {
        private readonly IStoriesProvider _storiesProvider;

        public BestStoriesController(IStoriesProvider storiesProvider)
        {
            _storiesProvider = storiesProvider;
        }

        [HttpGet("{n}", Name = "GetBestStories")]
        [ResponseCache(CacheProfileName = "Default30")]
        public Results<NotFound, Ok<IAsyncEnumerable<BestStory>>, BadRequest> Get(int n)
        {
            try
            {
                var bestStories = _storiesProvider.GetBestNStories(n);
                return bestStories == null ? TypedResults.NotFound() : TypedResults.Ok(bestStories);
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
        }
    }
}
