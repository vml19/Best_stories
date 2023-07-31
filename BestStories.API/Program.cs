using BestStories.BusinessLogic.Services.Contracts;
using BestStories.BusinessLogic.Services.Respository;
using BestStories.Channel.Services.Contracts;
using BestStories.Data.Services.Contracts;
using BestStories.Data.Services.Repository;
using BestStories.Repository.Services.Respository;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStoriesProvider, StoriesProvider>();
builder.Services.AddScoped<IStoryDataManager, StoryDataManager>();
builder.Services.AddScoped<IRestClient, RestClient>();
builder.Services.AddHttpClient();

builder.Services.AddResponseCaching();
builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("Default30",
        new CacheProfile()
        {
            Duration = 30
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();
