using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class Comment
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? PostId { get; set; }
    public string? Content { get; set; }
    public DateTime PublicationDate { get; set; }
    
    [JsonIgnore]
    public virtual Post? Post { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
}
