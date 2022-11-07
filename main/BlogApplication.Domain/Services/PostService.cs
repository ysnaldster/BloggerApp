using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Interfaces;

namespace BlogApplication.Domain.Services;

public class PostService : IPostService
{
    
    private readonly IPostRepository _postRepository;
    
    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public bool GetDatabaseConnection()
    {
        return _postRepository.GetDatabaseConnection();
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post? GetPost(Guid id)
    {
        return _postRepository.GetPost(id);
    }

    public Post? SavePost(Post post)
    {
        return _postRepository.SavePost(post);
    }

    public Post? UpdatePost(Guid id, Post post)
    {
        return _postRepository.UpdatePost(id, post);
    }

    public Post? DeletePost(Guid id)
    {
        return _postRepository.DeletePost(id);
    }
}

