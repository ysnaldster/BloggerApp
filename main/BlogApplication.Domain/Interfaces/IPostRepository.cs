using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Interfaces;

public interface IPostRepository
{
    public bool GetDatabaseConnection();
    public IEnumerable<Post> GetAllPosts();

    public Post? GetPost(Guid id);

    public Post? SavePost(Post post);

    public Post? UpdatePost(Guid id, Post post);

    public Post? DeletePost(Guid id);
}