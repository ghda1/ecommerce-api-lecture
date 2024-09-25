// Create new user dto
public record CreateUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Position { get; set; }
    public required string Password { get; set; }

}