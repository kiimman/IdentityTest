using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppIdentity.Services;
using WebAppIdentity.ViewModels;

namespace WebAppIdentity.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly AuthService _auth;

        public AccountController(AuthService auth)
        {
            _auth = auth;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (await _auth.SignUpAsync(model))
                    return RedirectToAction("SignIn");

                ModelState.AddModelError("", "A user with the same email already exists");

            }

            return View(model);
        }


    }
}
