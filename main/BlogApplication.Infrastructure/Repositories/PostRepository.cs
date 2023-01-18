using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Interfaces;
using BlogApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogApplicationContext _context;

    public PostRepository(BlogApplicationContext dbContext)
    {
        _context = dbContext;
    }

    public bool GetDatabaseConnection()
    {
        return _context.Database.EnsureCreated();
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Post?> GetPost(Guid? id)
    {
        return await _context.Posts.AsNoTracking()
            .Include(p => p.User)
            .Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Post> SavePost(Post? post)
    {
        if (post == null) throw new ArgumentNullException(nameof(post));
        await _context.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post> UpdatePost(Guid? id, Post? post)
    {
        if (post == null || id == null) throw new ArgumentNullException(nameof(post));
        var actualPost = await _context.Posts.SingleOrDefaultAsync(p => p.Id == id);
        if (actualPost == null) return post;
        actualPost.Author = post.Author;
        actualPost.Category = post.Category;
        actualPost.Comments = post.Comments;
        actualPost.Content = post.Content;
        actualPost.Status = post.Status;
        actualPost.Title = post.Title;
        actualPost.User = post.User;
        await _context.SaveChangesAsync();
        return actualPost;
    }

    public async Task<Post?> DeletePost(Guid id)
    {
        var postToDelete = await _context.Posts
            .Where(s => s.Id == id)
            .Include(p => p.User)
            .Include(p => p.Category)
            .SingleOrDefaultAsync();
        if (postToDelete == null) return postToDelete;
        _context.Remove(postToDelete!);
        await _context.SaveChangesAsync();
        return postToDelete;
    }
}