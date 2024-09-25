// Users Controller

using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/users")]

public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // //? GET => /api/users => Get all the users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsersService();
        return Ok(users);
    }

    // //? GET => /api/users/{id} => Get a single user by Id
    [HttpGet("{id:guid}")]
    public IActionResult GetUserById(Guid id)
    {
        var user = _userService.GetUserByIdService(id);
        if (user == null)
        {
            return NotFound($"User with this {id} does not exist");
        }
        return Ok(user);
    }


    // //? Delete => /api/users/{id} => delete a single user by Id
    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(Guid id)
    {
        var result = _userService.DeleteUserByIdService(id);
        if (!result)
        {
            return NotFound($"User with this {id} does not exist");
        }
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserDto newUser)
    {
        // check validation before create the new user
        if (!UserValidation.isValidString(newUser.Name))
        {
            return BadRequest("Name can not be empty 11");
        }
        if (!UserValidation.isValidString(newUser.Email))
        {
            return BadRequest("Email can not be empty");
        }
        if (UserValidation.isValidEmail(newUser.Email) == false)
        {
            return BadRequest("Email is not valid");
        }
        if (!UserValidation.isValidString(newUser.Position))
        {
            return BadRequest("Position can not be empty");
        }
        if (!UserValidation.isValidString(newUser.Password))
        {
            return BadRequest("Password can not be empty");
        }
        if (!UserValidation.isValidPassword(newUser.Password))
        {
            return BadRequest("Password can not be less than 7 charcter");
        }
        var user = _userService.CreateUserService(newUser);
        return Created($"/api/users/{user.Id}", user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UpdateUserDto updateUser)
    {
        // found the user then check the validation before update the user
        var foundUpdatedUser = _userService.GetUserByIdService(id);

        if (foundUpdatedUser == null)
        {
            return NotFound($"User with this {id} not found");
        }

        if (updateUser.Name != null)
        {

            if (!UserValidation.isValidString(updateUser.Name))
            {
                return BadRequest("Name can not be empty");
            }
        }
        if (updateUser.Email != null)
        {

            if (!UserValidation.isValidString(updateUser.Email))
            {
                return BadRequest("Email can not be empty");
            }
            if (UserValidation.isValidEmail(updateUser.Email) == false)
            {
                return BadRequest("Email is not valid");
            }

        }
        if (updateUser.Position != null)
        {

            if (!UserValidation.isValidString(updateUser.Position))
            {
                return BadRequest("Position can not be empty");
            }
        }
        if (updateUser.Password != null)
        {

            if (!UserValidation.isValidString(updateUser.Password))
            {
                return BadRequest("Password can not be empty");
            }
            if (!UserValidation.isValidPassword(updateUser.Password))
            {
                return BadRequest("Password can not be less than 7 charcter");
            }
        }


        foundUpdatedUser = _userService.UpdateUserService(id, updateUser);

        return Ok(foundUpdatedUser);
    }

}