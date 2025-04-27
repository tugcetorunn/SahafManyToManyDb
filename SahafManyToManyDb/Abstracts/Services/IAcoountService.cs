using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SahafManyToManyDb.ResultViewModels;
using SahafManyToManyDb.ViewModels.Accounts;
using System.Security.Claims;

namespace SahafManyToManyDb.Abstracts.Services
{
    public interface IAcoountService
    {
        /// <summary>
        /// accountService i soyutlamak üzere yazılan interface
        /// </summary>
        public interface IAccountService
        {
            LoginResult Login(LoginVM vm);
            Task<RegisterResult> Register(RegisterVM vm);
            string UserIdGetir(ClaimsPrincipal uye); // controllerlarda user id gereken noktalarda kullanılmak üzere yazılan metod
        }
    }
}
