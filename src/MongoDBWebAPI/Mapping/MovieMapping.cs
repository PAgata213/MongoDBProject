using MongoDBProj.Domain.Models;
using MongoDBProj.WebAPI.DTO;

namespace MongoDBProj.WebAPI.Mapping;

public static class MovieMapping
{
	public static MovieDTO ToDTO(this Movie movie)
		=> new()
		{
			Description = movie.Description,
			Id = movie.Id,
			Name = movie.Name,
			Title = movie.Title,
		};

	public static Movie ToMovie(this MovieDTO movie)
		=> new()
		{
			Id = movie.Id!,
			Description = movie.Description,
			Name = movie.Name,
			Title = movie.Title,
		};
}
