using MongoDBProj.Domain.Models;

namespace MongoDBProj.Domain.Interfaces;
public interface IMovieRepository
{
	public Task<ICollection<Movie>> GetMoviesAsync();
	public ValueTask<Movie> GetMovieByIdAsync(string movieId);
	public Task CreateMovieAsync(Movie movie);
	public Task UpdateMovieAsync(Movie movie);
	public Task DeleteMovieAsync(string movieId);
}