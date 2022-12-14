using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Interfaces;
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

    [HttpGet]
    [Route("connection")]
    public IActionResult GetConnection()
    {
        _postService.GetDatabaseConnection();
        return Ok("database created");
    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

    [HttpGet]
    [Route("posts")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var result = await _postService.GetAllPosts();
        if (result.Any()) return Ok(result);
        return NotFound();
    }

    [HttpGet]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> GetPost(Guid id)
    {
        var result = await _postService.GetPost(id);
        if (result != null) return Ok(result);
        return NotFound();
    }

    [HttpPost]
    [Route("posts")]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post? post)
    {
        if (post == null) return BadRequest();
        var result = await _postService.SavePost(post);
        _logger.LogInformation("Create post successes");
        return Ok(result);
    }

    [HttpPut]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> UpdatePost(Guid? id, [FromBody] Post? post)
    {
        if (post == null || id == null) return BadRequest();
        var result = await _postService.UpdatePost(id, post);
        return Ok(result);
    }

    [HttpDelete]
    [Route("posts/{id}")]
    public async Task<ActionResult<Post>> DeletePost(Guid id)
    {
        var result = await _postService.DeletePost(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}