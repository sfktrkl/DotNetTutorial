using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}