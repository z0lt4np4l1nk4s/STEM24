namespace STEM24.Abstractions.Service;

/// <summary>
/// Smtp service
/// </summary>
public interface ISmtpService
{
    /// <summary>
    /// Send email asynchronously
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="subject">Subject</param>
    /// <param name="content">Content</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> SendAsync(string email, string subject, string content);
}
