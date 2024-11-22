using FastEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.Domain.Models;
using MongoDBProj.WebAPI.DTO;
using MongoDBProj.WebAPI.Mapping;

namespace MongoDBProj.WebAPI.WebAPI;

public class GetMovieById(IMovieRepository _movieRepository) : EndpointWithoutRequest<Results<Ok<MovieDTO>, NotFound, ProblemDetails>>
{
	private readonly IMovieRepository _movieRepository = _movieRepository;

	public override void Configure()
	{
		Get("/api/movies/{movieId}/");
		AllowAnonymous();
	}

	public override async Task<Results<Ok<MovieDTO>, NotFound, ProblemDetails>> ExecuteAsync(CancellationToken ct)
	{
		var movieId = Route<string>("movieId");
		if(string.IsNullOrEmpty(movieId))
		{
			AddError("Empty argument : movieId");
			return new FastEndpoints.ProblemDetails();
		}
		var movie = await _movieRepository.GetMovieByIdAsync(movieId);
		return movie is null 
			? TypedResults.NotFound() 
			: TypedResults.Ok(movie.ToDTO());
	}
}
