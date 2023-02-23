using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class Category
{
    public enum CategoryName
    {
        Literature,
        Sports,
        Shows,
    }

    public Category(Guid id, CategoryName name)
    {
        Id = id;
        Name = name;
    }
    
    public Category(){}
    public Guid Id { get; set; }
    public CategoryName Name { get; set; }

    [JsonIgnore] public virtual ICollection<Post>? Posts { get; set; }
    
}