using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Api.Controllers;

[ApiController]
[Route("[controller]/api")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly IUserService _userService;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    
    /// <summary>
    /// GetAllUserList
    /// </summary>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var result = await _userService.GetAllUsers();
        if (!result.Any()) return NotFound();
        _logger.LogInformation("Users obtained");
        return Ok(result);
    }
    
    /// <summary>
    /// FindUserById
    /// </summary>
    /// <param name="id">User data by id</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("users/{id}")]
    public async Task<ActionResult<Post>> GetUser(Guid id)
    {
        var result = await _userService.GetUser(id);
        if (result == null) return NotFound();
        _logger.LogInformation($"User by Id: {id} obtained");
        return Ok(result);
    }
    
    /// <summary>
    /// CreateNewUserUsingJsonBody
    /// </summary>
    /// <param name="user">User body to create<</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPost]
    [Route("users")]
    public async Task<ActionResult<Post>> CreateUser([FromBody] User? user)
    {
        if (user == null) return BadRequest();
        var result = await _userService.SaveUser(user);
        _logger.LogInformation("Create user successes");
        return Ok(result);
    }
    
    /// <summary>
    /// UpdateUserDataUsingJsonBody
    /// </summary>
    /// <param name="id">Post id to update</param>
    /// <param name="user">>Post body to update</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPut]
    [Route("users/{id}")]
    public async Task<ActionResult<User>> UpdateUser(Guid? id, [FromBody] User? user)
    {
        if (user == null || id == null) return BadRequest();
        var result = await _userService.UpdateUser(id, user);
        _logger.LogInformation($"User by id {id} updated");
        return Ok(result);
    }
    
    /// <summary>
    /// DeletePostById
    /// </summary>
    /// <param name="id">Comment id to delete</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpDelete]
    [Route("users/{id}")]
    public async Task<ActionResult<User>> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUser(id);
        if (result == null) return NotFound();
        _logger.LogInformation($"User by id {id} deleted");
        return Ok(result);
    }
}