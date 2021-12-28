using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tutorial.Repository;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                // Check the result of the operation. Since identity core
                // is doing the validation it may be unsuccessfull if
                // the given emails is already exist, or password doesn't
                // match with the validations. It is important to know that
                // those settings can be changed/updated, still some of them
                // are provided as default.
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
                return View();
            }
            return View(userModel);
        }
    }
}
