namespace STEM24.Model.Entity;

/// <summary>
/// Comment entity
/// </summary>
public class CommentEntity
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Event identifier
    /// </summary>
    public Guid EventId { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    public string Text { get; set; } = default!;

    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    public DateTime UpdateTime { get; set; }
}
