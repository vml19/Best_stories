﻿using BestStories.BusinessLogic.Services.Contracts;
using BestStories.Model;
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
        public async IAsyncEnumerable<BestStory> Get(int n)
        {
            await foreach (var bestStory in _storiesProvider.GetFirstNBestStories(n))
            {
                yield return bestStory;
            }
        }
    }
}
