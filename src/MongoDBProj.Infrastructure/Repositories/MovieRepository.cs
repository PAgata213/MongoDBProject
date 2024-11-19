using MongoDB.Driver;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.Domain.Models;
using MongoDBProj.Infrastructure.DbContext;

namespace MongoDBProj.Infrastructure.Repositories;
internal class MovieRepository : IMovieRepository
{
	private readonly IMongoDbContext _mongoDBContext;
	private readonly IMongoCollection<Movie> _movieCollection;

	public MovieRepository(IMongoDbContext mongoDBContext)
	{
		_mongoDBContext = mongoDBContext;
		_movieCollection = _mongoDBContext.DataBase.GetCollection<Movie>("movie");
	}

	public async Task<ICollection<Movie>> GetMovies()
		=> await _movieCollection.Find(FilterDefinition<Movie>.Empty).ToListAsync();

	public async ValueTask<Movie> GetMovieById(Guid movieId)
		=> await _movieCollection
				.Find(Builders<Movie>.Filter.Eq(x => x.Id, movieId))
				.FirstOrDefaultAsync();

	public async Task CreateMovie(Movie movie)
		=> await _movieCollection.InsertOneAsync(movie);

	public async Task UpdateMovie(Movie movie)
	{
		var filter = Builders<Movie>.Filter.Eq(x => x.Id, movie.Id);
		//var update = Builders<Movie>.Update
		//	.Set(x => x.Title, movie.Title)
		//	.Set(x => x.Description, movie.Description)
		//	.Set(x => x.Name, movie.Name);
		//await _movieCollection.UpdateOneAsync(filter, update);

		//OR

		await _movieCollection.ReplaceOneAsync(filter, movie);
	}

	public async Task DeleteMovie(Guid movieId)
		=> await _movieCollection.DeleteOneAsync(Builders<Movie>.Filter.Eq(x => x.Id,movieId));

}
