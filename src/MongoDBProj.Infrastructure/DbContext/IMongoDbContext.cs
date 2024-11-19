using MongoDB.Driver;

namespace MongoDBProj.Infrastructure.DbContext;

public interface IMongoDbContext
{
	IMongoDatabase DataBase { get; }
}