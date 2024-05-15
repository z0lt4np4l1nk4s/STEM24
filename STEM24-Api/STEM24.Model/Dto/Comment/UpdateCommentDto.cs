namespace STEM24.Model.Dto;

/// <summary>
/// Update comment model
/// </summary>
public class UpdateCommentDto
{
    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    [Required]
    public string Text { get; set; } = default!;
}
