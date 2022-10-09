namespace BlogApplication.Domain.Entities;

public class PostLabelPivot
{
    public Guid Id { get; set;}
    public Guid PostId { get; set;}
    public Guid LabelId { get; set;}
    
    public virtual Post Post { get; set;}
    public virtual Label Label { get; set;}

}