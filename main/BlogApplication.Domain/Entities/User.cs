using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public User(Guid id, string name, string password, string nickname, string email, DateTime creationDate, DateTime updateDate)
    {
        Id = id;
        Name = name;
        Password = password;
        Nickname = nickname;
        Email = email;
        UpdateDate = updateDate;
        CreationDate = creationDate;
    }
    
    public User(){}
    [JsonIgnore] public virtual ICollection<Post>? Posts { get; set; }

    [JsonIgnore] public virtual ICollection<Comment>? Comments { get; set; }
}