using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Repositories;
using BlogApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogApplicationContext _context;

    public CommentRepository(BlogApplicationContext dbContext)
    {
        _context = dbContext;
    }
    
    
    public async Task<IEnumerable<Comment>> GetAllComments()
    {
        return await _context.Comments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Comment?> GetComment(Guid? id)
    {
        return await _context.Comments.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Comment> SaveComment(Comment? comment)
    {
        if (comment == null) throw new ArgumentNullException(nameof(comment));
        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment> UpdateComment(Guid? id, Comment? comment)
    {
        if (comment == null || id == null) throw new ArgumentNullException(nameof(comment));
        var actualComment = await _context.Comments.SingleOrDefaultAsync(p => p.Id == id);
        if (actualComment == null) return comment;
        actualComment.Content = comment.Content;
        await _context.SaveChangesAsync();
        return actualComment;    }

    public async Task<Comment?> DeleteComment(Guid id)
    {
        var commentToDelete = await _context.Comments
            .Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (commentToDelete == null) return commentToDelete;
        _context.Remove(commentToDelete!);
        await _context.SaveChangesAsync();
        return commentToDelete;
    }
}