// Model

public record User
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; set; }

}