using SeagullflyMaui.Model;

namespace SeagullflyMaui.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
