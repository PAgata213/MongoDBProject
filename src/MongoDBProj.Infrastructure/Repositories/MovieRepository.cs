using MongoDBProj.Domain.Interfaces;
using MongoDBProj.Domain.Models;

namespace MongoDBProj.Infrastructure.Repositories;
internal class MovieRepository : IMovieRepository
{
	public ValueTask<Guid> CreateMovie(Movie movie) => throw new NotImplementedException();
	public Task DeleteMovie(Guid movieId) => throw new NotImplementedException();
	public ValueTask<Movie> GetMovieById(Guid movieId) => throw new NotImplementedException();
	public Task<ICollection<Movie>> GetMovies() => throw new NotImplementedException();
	public Task UpdateMovie(Movie movie) => throw new NotImplementedException();
}
