namespace STEM24.Model.Entity;

public class DnsRecordEntity
{
    public Guid Id { get; set; }

    public string Type { get; set; } = default!;

    public string Content { get; set; } = default!;

    public string Name { get; set; } = default!;
}
