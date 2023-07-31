# Best Stories
RESTful API to retrieve the details of the best n stories from the Hacker News API.

## Environment
.NET 7.0, Visual Studio 2022, NUnit & MoQ

## Run the application
1. Clone https://github.com/vml19/best_stories.git
2. Open BestStories.sln in Visual Studio 2022 and run BestStories.API project
3. Application should be up and running at http://localhost:5204/swagger/index.html
4. Test GET /api/BestStories/{n} by inputting value for n, also the GET method can be tested using http://localhost:5204/api/BestStories/2 as well
5. Unit test projects can be executed from Test -> Test Explorer

## Assumptions
Slowness in fetching the best stories is well understood as every new request (with different parameter) requires retrieval of all best stories from Hacker News API and getting story details for each story are bit of time-consuming tasks.

## Future enhancements
1. Improve Api response time by having a separate back-end service for locally storing and frequently updating Best Stories from Hacker News API, this way is more efficient as BestStories.API just to need serve users by retrieving Best Stories from local persistent store itself, does not need to hit the Api everytime and keep the user to wait.
2. Improved caching mechanism for faster API response time.
3. Proper exception handing.
4. Separate module for Rest calls.
