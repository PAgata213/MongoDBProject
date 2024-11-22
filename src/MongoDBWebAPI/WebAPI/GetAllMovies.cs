using FastEndpoints;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.WebAPI.DTO;
using MongoDBProj.WebAPI.Mapping;

namespace MongoDBProj.WebAPI.WebAPI;

public class GetAllMovies(IMovieRepository _movieRepository) : Endpoint<EmptyRequest, ICollection<MovieDTO>>
{
	private readonly IMovieRepository _movieRepository = _movieRepository;
	public override void Configure()
	{
		Get("/api/movies/");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var movies = await _movieRepository.GetMoviesAsync();
		Response = movies.Select(m => m.ToDTO()).ToList();
	}
}
