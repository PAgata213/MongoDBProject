namespace MongoDBProj.WebAPI.DTO;

public record MovieDTO
{
	public string? Id { get; init; }

	public string? Name { get; set; }

	public string? Description { get; set; }

	public string? Title { get; set; }
}
