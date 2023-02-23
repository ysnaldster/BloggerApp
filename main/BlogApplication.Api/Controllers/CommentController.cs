using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Api.Controllers;

[ApiController]
[Route("[controller]/api")]
public class CommentController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService, ILogger<UserController> logger)
    {
        _commentService = commentService;
        _logger = logger;
    }
    
    /// <summary>
    /// GetAllCommentList
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("comments")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        var result = await _commentService.GetAllComments();
        if (result.Any()) return Ok(result);
        return NotFound();
    }
    
    [HttpGet]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> GetComment(Guid id)
    {
        var result = await _commentService.GetComment(id);
        if (result != null) return Ok(result);
        return NotFound();
    }
    
    [HttpPost]
    [Route("comments")]
    public async Task<ActionResult<Comment>> CreateComment([FromBody] Comment? comment)
    {
        if (comment == null) return BadRequest();
        var result = await _commentService.SaveComment(comment);
        _logger.LogInformation("Create comment successes");
        return Ok(result);
    }

    [HttpPut]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> UpdateComment(Guid? id, [FromBody] Comment? comment)
    {
        if (comment == null || id == null) return BadRequest();
        var result = await _commentService.UpdateComment(id, comment);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> DeleteComment(Guid id)
    {
        var result = await _commentService.DeleteComment(id);
        if (result == null) return NotFound();
        return Ok(result);
    }
}