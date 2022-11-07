using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;

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
        return Ok();
    }

    [HttpGet]
    [Route("posts")]
    public IEnumerable<Post> GetPosts()
    {
        return _postService.GetAllPosts();
    }

    [HttpGet]
    [Route("posts/{id}")]
    public ActionResult<Post> GetPost(Guid id)
    {
        try
        {
            var result = _postService.GetPost(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    [Route("posts")]
    public ActionResult<Post> CreatePost([FromBody] Post post)
    {
        _logger.LogInformation("Create post successes");
        try
        {
            var result = _postService.SavePost(post);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Route("posts/{id}")]
    public ActionResult<Post> UpdatePost(Guid id, [FromBody] Post post)
    {
        _logger.LogInformation("Update post successes");
        try
        {
            var result = _postService.UpdatePost(id, post);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Route("posts/{id}")]
    public ActionResult<Post> DeletePost(Guid id)
    {
        try
        {
            var result = _postService.DeletePost(id);
            _logger.LogInformation("Delete post successes");
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}