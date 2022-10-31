using BlogApplication.Domain.Interfaces;
using BlogApplication.Infrastructure.Interfaces;

namespace BlogApplication.Domain.Services;

public class PostService : IPostService
{
    
    private readonly IPostRepository _postRepository;
    
    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    /*
    public Task<bool> GetDatabaseConnection()
    {
        return _postRepository.GetDatabaseConnection();
    }
    
    public Task<string> GetAllPosts()
    {
        throw new NotImplementedException();
    }
    */
}

