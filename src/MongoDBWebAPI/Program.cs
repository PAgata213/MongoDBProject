using FastEndpoints;
using FastEndpoints.Swagger;

using MongoDBProj.Infrastructure;
using MongoDBProj.Infrastructure.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.RegisterIntrastructure();
builder.Services.AddFastEndpoints()
									.SwaggerDocument();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetService<IMongoDbContext>();
	await dbContext!.DataBase.CreateCollectionAsync("movie");
}

// Configure the HTTP request pipeline.
//if(app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

app.UseFastEndpoints()
	.UseSwaggerGen();

app.Run();
