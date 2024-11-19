using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

namespace MongoDBProj.Infrastructure.DbContext;
internal class MongoDbContext : IMongoDbContext
{
	public IMongoDatabase DataBase => _database;

	private readonly IMongoDatabase _database;
	private readonly MongoClient _client;
	public MongoDbContext(IConfiguration config)
	{
		string connectionString = config.GetConnectionString("MongoDb")
			?? throw new ArgumentException("MongoDB connection string");
		var mongoUrl = new MongoUrl(connectionString);
		_client = new MongoClient(mongoUrl);
		_database = _client.GetDatabase("GeekLemon");
	}
}
