using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };

            return await _userManager.CreateAsync(user, userModel.Password);
        }
    }
}
