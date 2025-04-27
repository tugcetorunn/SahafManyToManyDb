using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SahafManyToManyDb.ResultViewModels;
using SahafManyToManyDb.ViewModels.Accounts;
using static SahafManyToManyDb.Abstracts.Services.IAcoountService;
using System.Security.Claims;
using SahafManyToManyDb.Data;
using SahafManyToManyDb.Models;

namespace SahafManyToManyDb.Services
{
    /// <summary>
    /// userManager yardımıyla kullanıcı oluşturma, giriş yapma işlemlerini controller dan uzaklaştırmak üzere oluşturulmuş service
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly SahafDbContext context;
        private readonly UserManager<Yazar> userManager;
        public AccountService(UserManager<Yazar> _userManager, SahafDbContext _context)
        {
            userManager = _userManager;
            context = _context;
        }

        public LoginResult Login(LoginVM vm)
        {
            LoginResult loginResult = new(); // üyeyi, sonucu ve mesajı döndürecek result class
            var user = userManager.FindByNameAsync(vm.KullaniciAdi).Result;
            if (user != null)
            {
                var result = userManager.CheckPasswordAsync(user, vm.Sifre).Result;
                if (result)
                {
                    // signin metodunu controller da çalıştıracağız.
                    loginResult.Yazar = user;
                }
                else
                {
                    loginResult.Yazar = null;
                    loginResult.Mesaj = "Şifre yanlış.";
                }
            }
            else
            {
                loginResult.Yazar = null;
                loginResult.Mesaj = "Kullanıcı bulunamadı.";
            }

            return loginResult;
        }

        public async Task<RegisterResult> Register(RegisterVM vm)
        {
            var user = new Yazar
            {
                UserName = vm.KullaniciAdi,
                Email = vm.Email,
                Ad = vm.Ad,
                Soyad = vm.Soyad
            };

            var result = await userManager.CreateAsync(user, vm.Sifre);
            // kullanıcı oluşturma işlemi başarılı ise
            if (result.Succeeded)
            {
                return new RegisterResult
                {
                    Hatalar = null
                };
            }
            else
            {
                // hata var, hataları döndür
                RegisterResult registerResult = new()
                {
                    Hatalar = result.Errors.Select(e => e.Description).ToList(),
                };
                return registerResult;
            }
        }

        public string UserIdGetir(ClaimsPrincipal uye)
        {
            var userId = userManager.GetUserId(uye);
            return userId;
        }

    }
}
