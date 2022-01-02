using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForgotPassword(UserEmailOptions userEmailOptions);
    }
}