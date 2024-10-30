using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaGestionDeCitas.Dto;

namespace SistemaGestionDeCitas.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        [BindProperty]
        public ConfirmEmailDto confirmEmailDto { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            
        
        }

    }
}
