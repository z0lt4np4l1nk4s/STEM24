namespace STEM24.Model.Dto;

/// <summary>
/// Dns record model
/// </summary>
public class DnsRecordDto
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    public string Type { get; set; } = default!;

    /// <summary>
    /// Content
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = default!;
}
