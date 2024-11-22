using FastEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.Domain.Models;
using MongoDBProj.WebAPI.DTO;

namespace MongoDBProj.WebAPI.WebAPI;

public class CreateMovie(IMovieRepository _movieRepository) : Endpoint<MovieDTO, Results<Ok, ProblemDetails>>
{
	private readonly IMovieRepository _movieRepository = _movieRepository;

	public override void Configure()
	{
		Post("/api/movies/");
		AllowAnonymous();
	}

	public override async Task HandleAsync(MovieDTO req, CancellationToken ct)
	{
		try
		{
			var newMovie = new Domain.Models.Movie
			{
				Description = req.Description,
				Name = req.Name,
				Title = req.Title,
			};
			await _movieRepository.CreateMovieAsync(newMovie);
			await SendCreatedAtAsync<GetMovieById>(new { movieID = newMovie.Id }, TypedResults.Ok(), cancellation: ct);
		}
		catch(Exception ex)
		{
			AddError(ex.Message);
			await SendErrorsAsync(cancellation: ct);
		}
	}
}
