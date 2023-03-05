using BlogApplication.Domain.Entities;

namespace tests.Utils.JSON;

public abstract class CommentJson
{
    public const string Content = "my new post";
    public static Comment BuildModel(
        string id = "3ee05129-86e3-4fe3-ac97-23510c79d1f6",
        string userId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb",
        string postId = "e97de533-9e22-4944-92bc-bdd799b6c785",
        string content = "when an unknown")
    {
        var time = new DateTime(2008, 6, 25, 11, 18, 35, 100);
        var comment = new Comment()
        {
            Id = Guid.Parse(id),
            UserId = Guid.Parse(userId),
            PostId = Guid.Parse(postId),
            Content = content,
            PublicationDate = time
        };
        return comment;
    }
    
    public static Comment CommentCreated()
    {
        return BuildModel("3ee05129-86e3-4fe3-ac97-23510c79d1f2", "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fdd", 
            "e97de533-9e22-4944-92bc-bdd799b6c786");
    }

}