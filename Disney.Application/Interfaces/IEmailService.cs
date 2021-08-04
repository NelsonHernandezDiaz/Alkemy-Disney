using Disney.Application.Models;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendMail(EmailInfo email);
    }
}
