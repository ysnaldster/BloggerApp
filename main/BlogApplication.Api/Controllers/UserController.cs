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
    /// <returns></returns>
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var result = await _userService.GetAllUsers();
        if (result.Any()) return Ok(result);
        return NotFound();
    }
    
    [HttpGet]
    [Route("users/{id}")]
    public async Task<ActionResult<Post>> GetUser(Guid id)
    {
        var result = await _userService.GetUser(id);
        if (result != null) return Ok(result);
        return NotFound();
    }
    
    [HttpPost]
    [Route("users")]
    public async Task<ActionResult<Post>> CreateUser([FromBody] User? user)
    {
        if (user == null) return BadRequest();
        var result = await _userService.SaveUser(user);
        _logger.LogInformation("Create user successes");
        return Ok(result);
    }
    
    [HttpPut]
    [Route("users/{id}")]
    public async Task<ActionResult<User>> UpdateUser(Guid? id, [FromBody] User? user)
    {
        if (user == null || id == null) return BadRequest();
        var result = await _userService.UpdateUser(id, user);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("users/{id}")]
    public async Task<ActionResult<User>> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUser(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}