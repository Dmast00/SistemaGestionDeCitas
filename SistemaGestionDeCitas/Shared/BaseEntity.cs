using Microsoft.AspNetCore.Identity;

namespace SistemaGestionDeCitas.Shared
{
    public class BaseEntity 
    {
        public int Id { get; set; }

        public DateTime CreatedDatetime { get; set; }
        public DateTime ModifiedDatetime { get; set; }
    }
}
