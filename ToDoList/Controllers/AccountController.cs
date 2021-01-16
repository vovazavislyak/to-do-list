using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if (await _userRepository.ContainsUserWithEmailAsync(model.Email))
            {
                ModelState.AddModelError("", "Incorrect login and (or) password");
                return View(model);
            }

            var user = new User {Email = model.Email, Name = model.Name, Password = model.Password};

            await _userRepository.AddUserAsync(user);

            await Authenticate(user);

            return RedirectToAction(nameof(ToDoController.GetAllTask), "ToDo");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _userRepository.IsCorrectEmailAndPasswordAsync(model.Email, model.Password))
            {
                var user = await _userRepository.GetUserAsync(model.Email);
                
                await Authenticate(user);
                
                return RedirectToAction(nameof(ToDoController.GetAllTask), "ToDo");
            }
            ModelState.AddModelError("", "Incorrect login and(or) password");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(Models.User.Id), user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name)
            };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}