using BlogApplication.Domain.Entities;

namespace test.Utils.JSON;

public abstract class UserJson
{

    public const string NameToChange = "Adelaida", Nickname = "adelaida_95";
    public static User BuildModel(
        string id = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb",
        string? name = "John",
        string? password = "123456",
        string? nickname = "John23",
        string? email = "john@mail.com")
    {
        var time = new DateTime(2008, 6, 25, 11, 18, 35, 100);
        var user = new User()
        {
            Id = Guid.Parse(id),
            Name = name!,
            Password = password!,
            Nickname = nickname!,
            Email = email!,
            CreationDate = time,
            UpdateDate = time
        };
        return user;
    }
    
    public static User UserCreated()
    {
        return BuildModel("8dd1b477-0d2b-42ae-bfd3-0de9d74b7fee", "Mauricio", 
            "1234567", "mauricio_91", "mauricio@mail.com");
    }
}