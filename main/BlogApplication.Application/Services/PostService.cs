using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Repositories;
using BlogApplication.Domain.Services;

namespace BlogApplication.Application.Services;

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

    public Task<IEnumerable<Post>> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Task<Post?> GetPost(Guid id)
    {
        return _postRepository.GetPost(id);
    }

    public Task<Post> SavePost(Post? post)
    {
        return _postRepository.SavePost(post);
    }

    public Task<Post> UpdatePost(Guid? id, Post? post)
    {
        return _postRepository.UpdatePost(id, post);
    }

    public Task<Post?> DeletePost(Guid id)
    {
        return _postRepository.DeletePost(id);
    }
}