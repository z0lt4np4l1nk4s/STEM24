namespace STEM24.Model.Dto;

/// <summary>
/// Add dns record model
/// </summary>
public class AddDnsRecordDto
{
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
