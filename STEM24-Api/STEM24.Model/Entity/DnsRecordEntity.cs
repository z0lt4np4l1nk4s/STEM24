﻿namespace STEM24.Model.Entity;

/// <summary>
/// Dns record entity
/// </summary>
public class DnsRecordEntity
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

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
