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
    /// FindAllCommentList
    /// </summary>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("comments")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        var result = await _commentService.GetAllComments();
        if (!result.Any()) return NotFound();
        _logger.LogInformation("Comments obtained"); 
        return Ok(result);
    }
    
    /// <summary>
    /// FindCommentById
    /// </summary>
    /// <param name="id">Comment id by to find</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpGet]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> GetComment(Guid id)
    {
        var result = await _commentService.GetComment(id);
        if (result == null) return NotFound();
        _logger.LogInformation($"Comment by Id: {id} obtained"); 
        return Ok(result);
    }
    
    /// <summary>
    /// CreateNewCommentUsingJsonBody
    /// </summary>
    /// <param name="comment">Comment body to create</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPost]
    [Route("comments")]
    public async Task<ActionResult<Comment>> CreateComment([FromBody] Comment? comment)
    {
        if (comment == null) return BadRequest();
        var result = await _commentService.SaveComment(comment);
        _logger.LogInformation("Comment created successful");
        return Ok(result);
    }
    
    /// <summary>
    /// UpdateCommentDataUsingJsonBody
    /// </summary>
    /// <param name="id">Comment id to update</param>
    /// <param name="comment">Comment body to update</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpPut]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> UpdateComment(Guid? id, [FromBody] Comment? comment)
    {
        if (comment == null || id == null) return BadRequest();
        var result = await _commentService.UpdateComment(id, comment);
        _logger.LogInformation($"Comment by id {id} updated");
        return Ok(result);
    }
    
    /// <summary>
    /// DeleteCommentById
    /// </summary>
    /// <param name="id">Comment id to delete</param>
    /// <returns>HttpStatusCode by result</returns>
    [HttpDelete]
    [Route("comments/{id}")]
    public async Task<ActionResult<Comment>> DeleteComment(Guid id)
    {
        var result = await _commentService.DeleteComment(id);
        if (result == null)
        {
            return NotFound();
        }
        _logger.LogInformation($"Comment by id {id} deleted"); 
        return Ok(result);
    }
}