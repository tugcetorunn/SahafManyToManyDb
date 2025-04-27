using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SahafManyToManyDb.Models;
using SahafManyToManyDb.ViewModels.Accounts;
using static SahafManyToManyDb.Abstracts.Services.IAcoountService;

namespace SahafManyToManyDb.Controllers
{
    /// <summary>
    /// view den kayıt, giriş, çıkış taleplerini karşılayan ve cevap dönen controller
    /// </summary>
    public class AccountController : Controller
    {
        private readonly SignInManager<Yazar> signInManager; // browsera kaydedeceği özellikler olduğu için controllerdan yürütüyoruz.
        private readonly IAccountService accountService;
        public AccountController(SignInManager<Yazar> _signInManager, IAccountService _accountService)
        {
            signInManager = _signInManager;
            accountService = _accountService;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            var loginResult = accountService.Login(vm);
            if (loginResult.Yazar != null)
            {
                await signInManager.SignInAsync(loginResult.Yazar, isPersistent: false);
                return RedirectToAction("Index", "Home"); // login başarılı olduğunda tüm notların listelendiği sayfaya gider
            }
            else
            {
                ModelState.AddModelError("", loginResult.Mesaj);
                return View(vm);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await accountService.Register(vm);
                if (registerResult.Hatalar.Count == 0)
                    return RedirectToAction("Login");
                else
                {
                    foreach (var item in registerResult.Hatalar)
                    {
                        ModelState.AddModelError("", item);
                    }
                    return View(vm);
                }

            }
            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
