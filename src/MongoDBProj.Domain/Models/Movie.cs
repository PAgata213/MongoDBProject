namespace MongoDBProj.Domain.Models;
public record Movie
{
	public Guid Id { get; init; } = Guid.NewGuid();

	public string? Name { get; set; }

	public string? Description { get; set; }

	public string? Title { get; set; }
}
