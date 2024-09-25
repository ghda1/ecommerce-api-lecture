// create product Dto
public record CreateProductDto
{
  public required string Name { get; set; }
  public required decimal Price { get; set; }
  public required string Description { get; set; }
}