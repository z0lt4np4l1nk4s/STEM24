namespace STEM24.Service;

/// <inheritdoc cref="ISmtpService" />
public class SmtpService : ISmtpService
{
    private readonly SmtpOptions _smtpOptions;

    public SmtpService(IOptions<SmtpOptions> smtpOptionsAccessor)
    {
        _smtpOptions = smtpOptionsAccessor.Value;
    }

    /// <inheritdoc cref="ISmtpService.SendAsync(string, string, string)" />
    public async Task<ServiceResult> SendAsync(string email, string subject, string content)
    {
        try
        {
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(_smtpOptions.Sender, _smtpOptions.Name),
                Subject = subject,
                Body = content,
            };
            mailMessage.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(_smtpOptions.Server, _smtpOptions.Port ?? 465))
            {
                client.Credentials = new NetworkCredential(_smtpOptions.Sender, _smtpOptions.Password);
                client.EnableSsl = true;

                await client.SendMailAsync(mailMessage);
            }

            return ServiceResult.Success();
        }
        catch
        {
            return ServiceResult.Failure("Failed to send email");
        }
    }
}
