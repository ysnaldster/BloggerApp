using BlogApplication.Infrastructure.Repositories;

namespace tests.BlogApplication.Infrastructure.Repository;

public class PostRepositoryTest 
{
    private readonly PostRepository _postRepository;

    public PostRepositoryTest(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [Fact]
    public void GetAllPosts_GiveAllData_ShouldReturnOk()
    {
        //Arrange
        //Act
        var result = _postRepository.GetAllPosts();
        //Assert
        Assert.NotNull(result);
    }
}