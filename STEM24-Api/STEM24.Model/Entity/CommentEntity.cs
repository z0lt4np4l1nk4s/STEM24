namespace STEM24.Model.Entity;

public class CommentEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public string Text { get; set; } = default!;

    public DateTime CreationTime { get; set; }

    public DateTime UpdateTime { get; set; }
}
