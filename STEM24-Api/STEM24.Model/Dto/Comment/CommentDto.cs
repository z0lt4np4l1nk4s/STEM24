namespace STEM24.Model.Dto;

/// <summary>
/// Comment model
/// </summary>
public class CommentDto
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    public string Text { get; set; } = default!;
    
    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime CreationTime { get; set; }
}
