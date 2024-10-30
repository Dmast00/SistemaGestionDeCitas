using Microsoft.AspNetCore.Identity;

namespace SistemaGestionDeCitas.Identity.Entity
{
    public class User : IdentityUser
    {
        public DateTime CreatedDatetime { get; set; }
        public DateTime ModifiedDatetime { get; set; }
    }
}
