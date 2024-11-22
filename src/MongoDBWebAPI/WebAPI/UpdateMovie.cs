using FastEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.WebAPI.DTO;
using MongoDBProj.WebAPI.Mapping;

namespace MongoDBProj.WebAPI.WebAPI;

public class UpdateMovie(IMovieRepository _movieRepository) : Endpoint<MovieDTO, Results<Ok, NotFound, ProblemDetails>>
{
	private readonly IMovieRepository _movieRepository = _movieRepository;
	public override void Configure()
	{
		Put("/api/movies/");
		AllowAnonymous();
	}

	public override async Task<Results<Ok, NotFound, ProblemDetails>> ExecuteAsync(MovieDTO req, CancellationToken ct)
	{
		if(req?.Id is null)
		{
			AddError("Empty argument : movieId");
			return new FastEndpoints.ProblemDetails();
		}
		await _movieRepository.UpdateMovieAsync(req.ToMovie());
		return TypedResults.Ok();
	}
}
