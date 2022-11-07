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

    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Category);
    }

    public Post? GetPost(Guid id)
    {
        return _context.Posts
            .Where(s => s.Id == id)
            .Include(p => p.User)
            .Include(p => p.Category)
            .SingleOrDefault();
    }

    public Post? SavePost(Post post)
    {
        try
        {
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Post? UpdatePost(Guid id, Post post)
    {
        var actualPost = _context.Posts.Find(id);
        if (actualPost != null)
        {
            actualPost.Author = post.Author;
            actualPost.Category = post.Category;
            actualPost.Comments = post.Comments;
            actualPost.Content = post.Content;
            actualPost.Status = post.Status;
            actualPost.Title = post.Title;
            actualPost.User = post.User;
             _context.SaveChanges();
            
        }
        return actualPost;
    }

    public Post? DeletePost(Guid id)
    {
        var postToDelete = _context.Posts
            .Where(s => s.Id == id)
            .Include(p => p.User)
            .Include(p => p.Category)
            .SingleOrDefault();
        if (postToDelete != null)
        {
            _context.Remove(postToDelete);
            _context.SaveChanges();
        }
        return postToDelete;
    }
}