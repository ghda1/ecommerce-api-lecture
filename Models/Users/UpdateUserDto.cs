// Update User Dto

public record UpdateUserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public string? Password { get; set; }

}