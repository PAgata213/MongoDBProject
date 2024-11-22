using FastEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

using MongoDBProj.Domain.Interfaces;

namespace MongoDBProj.WebAPI.WebAPI;

public class DeleteMovie(IMovieRepository _movieRepository) : EndpointWithoutRequest<Results<Ok, NotFound, ProblemDetails>>
{
	private readonly IMovieRepository _movieRepository = _movieRepository;

	public override void Configure()
	{
		Delete("/api/movies/{movieId}/");
		AllowAnonymous();
	}

	public override async Task<Results<Ok, NotFound, ProblemDetails>> ExecuteAsync(CancellationToken ct)
	{
		var movieId = Route<string>("movieId");
		if(string.IsNullOrEmpty(movieId))
		{
			AddError("Empty argument : movieId");
			return new FastEndpoints.ProblemDetails();
		}
		await _movieRepository.DeleteMovieAsync(movieId);
		return TypedResults.Ok();

	}
}
