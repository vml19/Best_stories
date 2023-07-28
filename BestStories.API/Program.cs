using BestStories.BusinessLogic.Services.Contracts;
using BestStories.BusinessLogic.Services.Respository;
using BestStories.Channel.Services.Contracts;
using BestStories.Channel.Services.Respository;
using BestStories.Data.Services.Contracts;
using BestStories.Data.Services.Repository;
using BestStories.Repository.Services.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStoriesProvider, StoriesProvider>();
builder.Services.AddScoped<IStoryDataManager, StoryDataManager>();
builder.Services.AddScoped<IExternalDataManager, ExternalDataManager>();
builder.Services.AddScoped<IApiClient, ApiClient>();
builder.Services.AddHttpClient();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
