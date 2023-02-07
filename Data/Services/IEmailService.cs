using WebSecurityDay3.Models;
using SendGrid;
using System.Threading.Tasks;


namespace WebSecurityDay3.Data.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailModel payload);
    }

}
