using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Repositories;

public interface ICommentRepository
{
    public Task<IEnumerable<Comment>> GetAllComments();

    public Task<Comment?> GetComment(Guid? id);

    public Task<Comment> SaveComment(Comment? post);

    public Task<Comment> UpdateComment(Guid? id, Comment? comment);

    public Task<Comment?> DeleteComment(Guid id);
}