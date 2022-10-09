using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class Category
{
    public Guid Id { get; set;}
    public CategoryName Name { get; set;}
    
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; set;}
    public enum CategoryName
    {
        Literature, Sports, Shows
    }
}