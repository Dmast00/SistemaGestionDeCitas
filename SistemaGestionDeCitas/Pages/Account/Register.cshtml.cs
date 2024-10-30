using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaGestionDeCitas.Dto;
using SistemaGestionDeCitas.Identity.Entity;

namespace SistemaGestionDeCitas.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        [BindProperty]
        public RegisterDto Register { get; set; }
        public string ReturnUrl { get; set; }
        public RegisterModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = new User();
                user.Email = Register.Email;
                user.UserName = Register.Email;
                user.CreatedDatetime = DateTime.Now;

                var response = await _userManager.CreateAsync(user, Register.Password);
                if(response.Errors.Count() != 0)
                {
                    ReturnUrl = "/Account/Register";
                }
                else 
                {
                    ReturnUrl = "/Account/Login";
                }

            }


            return LocalRedirect(ReturnUrl);
        }
    }
}
