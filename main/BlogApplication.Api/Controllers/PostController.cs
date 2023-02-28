using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Api.Controllers;

[ApiController]
[Route("[controller]/api")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;

    private readonly IPostService _postService;
    
    public PostController(IPostService postService, ILogger<PostController> logger)
    {
        _postService = postService;
        _logger = logger;
    }
    
    /// <summary>
    /// CheckPingApiConnection
    /// </summary>
    /// <returns>Information string response</returns>
    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
    
    /// <summary>
    /// CheckCreatedDatabaseConnection
    /// </summary>
    /// <returns>StatusCode</returns>
    [HttpGet]
    [Route("connection")]
    public IActionResult GetConnection()
    {
        if (_postService.GetDatabaseConnection()) return Ok();
        return NotFound();
    }
    
    /// <summary>
    /// GetAllPostList
    /// </summary>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("posts")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var result = await _postService.GetAllPosts();
        if (!result.Any()) return NotFound();
        _logger.LogInformation("Posts obtained");
        return Ok(result);
    }
    
    /// <summary>
    /// GetAPostById
    /// </summary>
    /// <param name="id">Post id by to find</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> GetPost(Guid id)
    {
        var result = await _postService.GetPost(id);
        if (result == null) return NotFound();
        _logger.LogInformation($"Post by Id: {id} obtained");
        return Ok(result);
    }
    
    /// <summary>
    /// CreateNewPostUsingJsonData
    /// </summary>
    /// <param name="post">Post body to create</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPost]
    [Route("posts")]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post? post)
    {
        if (post == null) return BadRequest();
        var result = await _postService.SavePost(post);
        _logger.LogInformation("Post created successful");
        return Ok(result);
    }
    
    /// <summary>
    /// UpdatePostUsingJsonData
    /// </summary>
    /// <param name="id">Post id to update</param>
    /// <param name="post">Post body to update</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPut]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> UpdatePost(Guid? id, [FromBody] Post? post)
    {
        if (post == null || id == null) return BadRequest();
        var result = await _postService.UpdatePost(id, post);
        _logger.LogInformation($"Post by id {id} updated");
        return Ok(result);
    }
    
    /// <summary>
    /// DeletePostById
    /// </summary>
    /// <param name="id">Post id to delete</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpDelete]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> DeletePost(Guid id)
    {
        var result = await _postService.DeletePost(id);
        if (result == null) return NotFound();
        _logger.LogInformation($"Post by id {id} deleted");
        return Ok(result);
    }
}