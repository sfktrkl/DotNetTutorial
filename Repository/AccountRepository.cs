using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };

            return await _userManager.CreateAsync(user, userModel.Password);
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInUserModel userModel)
        {
            return await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
        }
        
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
