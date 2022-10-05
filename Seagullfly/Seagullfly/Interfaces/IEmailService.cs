using Seagullfly.Models;
using System.Threading.Tasks;

namespace Seagullfly.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
