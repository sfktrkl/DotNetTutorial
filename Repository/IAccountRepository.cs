using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInUserModel userModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    }
}