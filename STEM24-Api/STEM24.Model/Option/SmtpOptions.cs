namespace STEM24.Model.Option;

/// <summary>
/// Smtp options
/// </summary>
public class SmtpOptions
{
    /// <summary>
    /// Server
    /// </summary>
    public string? Server { get; set; }

    /// <summary>
    /// Port
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Sender
    /// </summary>
    public string? Sender { get; set; }

    /// <summary>
    /// Password
    /// </summary>
    public string? Password { get; set; }
}
