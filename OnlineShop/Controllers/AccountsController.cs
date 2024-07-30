using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers;
using OnlineStore.Models.AccountsModels;
using OnlineStore.Models.DbModels;

namespace OnlineStore.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<OnlineStoreUser> userManager;

        private readonly SignInManager<OnlineStoreUser> signInManager;

        private readonly PasswordHasher<OnlineStoreUser> _passwordHasher;
        public AccountsController(UserManager<OnlineStoreUser> userManager,
            SignInManager<OnlineStoreUser> signInManager, PasswordHasher<OnlineStoreUser> passwordHasher)
        {
            this._passwordHasher = passwordHasher;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Route("/account/register")]
        public IActionResult Register()
        {
            return View("Register");
        }
        [Route("/account/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }
            if (ModelState.IsValid)
            {

                var user = new OnlineStoreUser
                {
                    UserName = model.FirstName,
                    Email = model.Email,
                   // IP = "123.345.567"
                };
                //// Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);
                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/");
                } else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"- {error.Description}");
                    }

                }
                await Console.Out.WriteLineAsync("eroare 1");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            } else
            {
                await Console.Out.WriteLineAsync("eroare 2");
            }
            return View(model);
        }

        [HttpGet]
        [Route("/account/login")]
        public IActionResult Login()
        {
            return View("login");
        }


        [HttpPost]
        [Route("/account/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var x in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Error: " + x.ErrorMessage);
                }
                Console.WriteLine("Invalid model");
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. User not found.");
                Console.WriteLine("User not found");
                return View(model);
            }

            //var passwordCheck = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            //if (passwordCheck == PasswordVerificationResult.Success)
            //{
               
                var signInResult = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                //else
                //{
                Console.WriteLine($"Login failed: {signInResult}");
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
                //}
            //}
            //else
            //{
            //Console.WriteLine("Password verification failed");

            //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //return View(model);
            //}
        }
        [HttpGet]
        [Authorize]
        [Route("/account/profile")]
        public IActionResult Login1()
        {
            return View("profile");
        }

    }
}
 