using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Services;

public interface ICommentService
{
    public Task<IEnumerable<Comment>> GetAllComments();

    public Task<Comment?> GetComment(Guid id);

    public Task<Comment> SaveComment(Comment comment);

    public Task<Comment> UpdateComment(Guid? id, Comment? comment);

    public Task<Comment?> DeleteComment(Guid id);
}