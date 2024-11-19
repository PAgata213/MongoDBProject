using MongoDBProj.Domain.Models;
using MongoDBProj.Infrastructure;
using MongoDBProj.Infrastructure.DbContext;
using MongoDBProj.WebAPI.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterIntrastructure();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetService<IMongoDbContext>();
	await dbContext!.DataBase.CreateCollectionAsync("movie");
}

	// Configure the HTTP request pipeline.
	if(app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

app.RegisterMovieWebAPI();

app.Run();
