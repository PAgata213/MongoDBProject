using Microsoft.AspNetCore.Mvc;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.WebAPI.DTO;

namespace MongoDBProj.WebAPI.WebAPI;

public static class MovieWebAPI
{
	public static void RegisterMovieWebAPI(this WebApplication app)
	{
		app.MapGet("/api/movies/", GetAllMovies);
		app.MapGet("/api/movies/{movieId}/", GetMovieById);
		app.MapPost("/api/movies/", CreateMovie);
		app.MapPut("/api/movies/", UpdateMovie);
		app.MapDelete("/api/movies/{movieId}/", DeleteMovie);
	}

	public static async Task<ICollection<MovieDTO>> GetAllMovies(IMovieRepository movieRepository)
	{
		var movies = await movieRepository.GetMoviesAsync();
		return movies.Select(x => new MovieDTO
		{
			Id = x.Id,
			Description = x.Description,
			Name = x.Name,
			Title = x.Title
		}).ToList();
	}

	public static async Task<MovieDTO?> GetMovieById(IMovieRepository movieRepository, string movieId)
	{
		var movie = await movieRepository.GetMovieByIdAsync(movieId);
		return new MovieDTO 
		{
			Id= movie.Id,
			Description = movie.Description,
			Name = movie.Name,
			Title = movie.Title
		};
	}

	public static async Task CreateMovie(IMovieRepository movieRepository, MovieDTO movie)
	{
		var newMovie = new Domain.Models.Movie
		{
			Description = movie.Description,
			Name = movie.Name,
			Title = movie.Title,
		};
		await movieRepository.CreateMovieAsync(newMovie);
	}

	public static async Task UpdateMovie(IMovieRepository movieRepository, MovieDTO movie)
	{
		var newMovie = new Domain.Models.Movie
		{
			Description = movie.Description,
			Name = movie.Name,
			Title = movie.Title,
		};
		await movieRepository.UpdateMovieAsync(newMovie);
	}

	public static async Task DeleteMovie(IMovieRepository movieRepository, string movieId)
	{
		await movieRepository.DeleteMovieAsync(movieId);
	}
}
