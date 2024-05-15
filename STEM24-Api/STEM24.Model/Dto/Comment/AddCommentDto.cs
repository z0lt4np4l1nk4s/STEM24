namespace STEM24.Model.Dto;

/// <summary>
/// Add comment model
/// </summary>
public class AddCommentDto
{
    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Event identifier
    /// </summary>
    [Required]
    public Guid EventId { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    [Required]
    public string Text { get; set; } = default!;
}
