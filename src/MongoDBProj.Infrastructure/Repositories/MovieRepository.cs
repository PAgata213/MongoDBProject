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

	public async Task<ICollection<Movie>> GetMoviesAsync()
		=> await _movieCollection.Find(FilterDefinition<Movie>.Empty).ToListAsync();

	public async ValueTask<Movie> GetMovieByIdAsync(string movieId)
		=> await _movieCollection
				.Find(Builders<Movie>.Filter.Eq(x => x.Id, movieId))
				.FirstOrDefaultAsync();

	public async Task CreateMovieAsync(Movie movie)
		=> await _movieCollection.InsertOneAsync(movie);

	public async Task UpdateMovieAsync(Movie movie)
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

	public async Task DeleteMovieAsync(string movieId) 
		=> await _movieCollection.DeleteOneAsync(Builders<Movie>.Filter.Eq(x => x.Id, movieId));
}
