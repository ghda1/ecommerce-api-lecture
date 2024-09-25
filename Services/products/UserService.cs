using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IUserService
{
    List<UserDto> GetUsersService();
    User CreateUserService(CreateUserDto createUser);
    bool DeleteUserByIdService(Guid id);
    UserDto? GetUserByIdService(Guid id);
    UserDto? UpdateUserService(Guid id, UpdateUserDto updateUser);

}
public class UserService : IUserService
{
    private static List<User> _users = new List<User>();

    public List<UserDto> GetUsersService()
    {
        // retrun the user as list of UserDto
        var users = _users.Select(user => new UserDto
        {
            Name = user.Name,
            Email = user.Email,
            Position = user.Position,
            CreatedAt = DateTime.Now,

        }).ToList();

        return users;
    }

    public User CreateUserService(CreateUserDto createUser)
    {
        //Create new user 
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = createUser.Name,
            Email = createUser.Email,
            Position = createUser.Position,
            Password = createUser.Password,
            CreatedAt = DateTime.Now,
        };
        _users.Add(user);
        return user;
    }

    public bool DeleteUserByIdService(Guid id)
    {
        // Find the user by id and delete it from the list
        var user = _users.FirstOrDefault(user => user.Id == id);

        if (user == null)
        {
            return false;
        }

        _users.Remove(user);
        return true;
    }


    public UserDto? GetUserByIdService(Guid id)
    {
        // find the user and return it as UserDto
        var user = _users.FirstOrDefault(user => user.Id == id);

        if (user == null)
        {
            return null;
        }

        var userData = new UserDto
        {
            Name = user.Name,
            Email = user.Email,
            Position = user.Position,
            CreatedAt = user.CreatedAt
        };

        return userData;
    }

    public UserDto? UpdateUserService(Guid id, UpdateUserDto updateUser)
    {
        // Find the user
        var user = _users.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            return null;
        }
        // Update the user 
        user.Name = updateUser.Name ?? user.Name;
        user.Email = updateUser.Email ?? user.Email;
        user.Position = updateUser.Position ?? user.Position;
        user.Password = updateUser.Password ?? user.Password;

        // return the user as UserDto
        var userData = new UserDto
        {
            Name = user.Name,
            Email = user.Email,
            Position = user.Position,
            CreatedAt = user.CreatedAt

        };

        return userData;
    }
}