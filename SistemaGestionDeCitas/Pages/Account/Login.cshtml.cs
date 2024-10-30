using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaGestionDeCitas.Dto;
using SistemaGestionDeCitas.Identity.Entity;

namespace SistemaGestionDeCitas.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signinManager;
        private readonly UserManager<User> _spNetUserManager;

        [BindProperty]
        public LoginDto Login { get; set; }
        public LoginModel(SignInManager<User> signInManager, UserManager<User> spNetUserManager)
        {
            _signinManager = signInManager;
            _spNetUserManager = spNetUserManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var res = await _signinManager.PasswordSignInAsync(Login.Email, Login.Password, true, true);

            if (res.Succeeded)
            {
                var user = await _spNetUserManager.FindByEmailAsync(Login.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    return Redirect("/Account/ConfirmEmail"); 

                }

                return Redirect("/");

            }
            else
            {
                return Redirect("/");

            }
        }
    }
}
