using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Services;

public interface IPostService
{
    public Task<IEnumerable<Post>> GetAllPosts();

    public Task<Post?> GetPost(Guid id);

    public Task<Post> SavePost(Post post);

    public Task<Post> UpdatePost(Guid? id, Post? post);

    public Task<Post?> DeletePost(Guid id);
}