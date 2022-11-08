using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Interfaces;

public interface IPostService
{
    
    public bool GetDatabaseConnection();
    public Task<IEnumerable<Post>> GetAllPosts();

    public Task<Post?> GetPost(Guid id);

    public Task<Post> SavePost(Post post);

    public Task<Post> UpdatePost(Guid? id, Post? post);

    public Task<Post?> DeletePost(Guid id);

}