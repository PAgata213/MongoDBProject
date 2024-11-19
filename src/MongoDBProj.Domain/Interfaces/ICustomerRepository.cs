using MongoDBProj.Domain.Models;

namespace MongoDBProj.Domain.Interfaces;
public interface IMovieRepository
{
	public Task<ICollection<Movie>> GetMovies();
	public ValueTask<Movie> GetMovieById(Guid movieId);
	public ValueTask<Guid> CreateMovie(Movie movie);
	public Task UpdateMovie(Movie movie);
	public Task DeleteMovie(Guid movieId);
}