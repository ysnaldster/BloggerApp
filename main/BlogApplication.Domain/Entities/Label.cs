using System.Text.Json.Serialization;

namespace BlogApplication.Domain.Entities;

public class Label
{
    public Guid Id { get; set;}
    public LabelName Name { get; set;}
    
    [JsonIgnore]
    public ICollection<PostLabelPivot> LabelPivots { get; set;}
    public enum LabelName
    {
        Happy, Surprise, Mood
    }
}