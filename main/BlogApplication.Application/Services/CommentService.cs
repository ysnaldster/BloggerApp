using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Repositories;
using BlogApplication.Domain.Services;

namespace BlogApplication.Application.Services;

public class CommentService : ICommentService
{
    
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public Task<IEnumerable<Comment>> GetAllComments()
    {
        return _commentRepository.GetAllComments();
    }

    public Task<Comment?> GetComment(Guid id)
    {
        return _commentRepository.GetComment(id);
    }

    public Task<Comment> SaveComment(Comment comment)
    {
        return _commentRepository.SaveComment(comment);
    }

    public Task<Comment> UpdateComment(Guid? id, Comment? comment)
    {
        return _commentRepository.UpdateComment(id, comment);
    }

    public Task<Comment?> DeleteComment(Guid id)
    {
        return _commentRepository.DeleteComment(id);
    }
}