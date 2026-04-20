using FileCloudSolution.DTOs;
using FileCloudSolution.Interfaces;
using FileCloudSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileCloudSolution.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    /// <summary>
    /// Returns all users registered to use cloud repository.
    /// </summary>
    [HttpGet(Name = "GetAllUsers")]
    public ActionResult<List<User>> Get()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    /// <summary>
    /// Add new user.
    /// </summary>
    [HttpPost(Name = "AddUser")]
    public ActionResult<UserDTO> Add(UserDTO user)
    {
        if (user == null)
        {
            return BadRequest("Please provide a valid user");
        }

        var createdUser = _userService.AddUser(user);

        return CreatedAtAction(
            nameof(Get),
            new { userName = createdUser.Name },
            createdUser
        );
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    [HttpDelete("{name}")]
    public ActionResult Delete ([FromRoute] string name)
    {
        _userService.RemoveUser(name);
        return Ok();
    }
}

