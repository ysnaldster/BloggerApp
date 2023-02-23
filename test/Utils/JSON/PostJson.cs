using BlogApplication.Domain.Entities;

namespace test.Utils.JSON;

public abstract class PostJson
{
    public const string AuthorToChange = "Alejandro", Title = "Alejandro's Article";

    public static Post BuildModel(
        string id = "e97de533-9e22-4944-92bc-bdd799b6c785",
        string? author = "Camila",
        string categoryId = "b7d0bbf0-a1e9-4dbd-845b-f8e751160000",
        string userId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb",
        string title = "The new things of technology")
    {
        var time = new DateTime(2008, 6, 25, 11, 18, 35, 100);
        var post = new Post()
        {
            Id = Guid.Parse(id),
            UserId = Guid.Parse(userId),
            CategoryId = Guid.Parse(categoryId),
            Title = title,
            PublicationDate = time,
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
            Author = author,
            Status = true,
            User = new User(
                Guid.Parse(userId),
                "John",
                "123456",
                "John23",
                "john@mail.com",
                time,
                time),
            Category = new Category(
                Guid.Parse(categoryId),
                Category.CategoryName.Literature)
        };
        return post;
    }

    public static Post PostCreated()
    {
        return BuildModel("98d7e4dc-70c5-4812-a3c4-e813ea59048b", "Alejandro", 
            "98d7e4dc-70c5-4812-a3c4-e813ea59ffff", "98d7e4dc-70c5-4812-a3c4-e813ea59eeee");
    }
    
}