using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string? Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string? Content { get; set; }
    public string? Author { get; set; }

    public bool Status { get; set; }
    public virtual User? User { get; set; }

    public virtual Category? Category { get; set; }

    [JsonIgnore] public virtual ICollection<Comment>? Comments { get; set; }

    [JsonIgnore] public virtual ICollection<PostLabelPivot>? PostPivots { get; set; }
}