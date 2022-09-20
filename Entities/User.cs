using System.Text.Json.Serialization;

namespace BlogApplication.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set;}
    public string Password { get; set;}
    public string Nickname { get; set;}
    public string Email { get; set;}
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    
    [JsonIgnore]
    public virtual ICollection <Post> Posts { get; set;}
    
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set;}
}