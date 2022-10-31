using BlogApplication.Infrastructure.Context;
using BlogApplication.Infrastructure.Interfaces;

namespace BlogApplication.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    IPost
    /*
    private readonly BlogApplicationContext _context;

    public PostRepository(BlogApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<bool> GetDatabaseConnection()
    {
        _context.Database.EnsureCreated();
        //return "Database in memory: " + _context.Database.IsInMemory();
        return true;
    }
    
    public Task<string> GetAllPosts()
    {
        throw new NotImplementedException();
    }
    */
}