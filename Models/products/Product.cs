// Model
public record Product
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public  required decimal Price { get; set; }
  public required string Description { get; set; }
  public DateTime CreatedAt { get; set; }

}