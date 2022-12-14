namespace BlogApplication.Domain.Entities;

public class Comment
{
    public Guid? Id { get; set; }
    public Guid? PostId { get; set; }
    public Guid? UserId { get; set; }
    public string? Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public virtual Post? Post { get; set; }
    public virtual User? User { get; set; }
}