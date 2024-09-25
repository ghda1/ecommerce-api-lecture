using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// User Dto to return specefic data 

public record UserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public DateTime CreatedAt { get; set; }
}