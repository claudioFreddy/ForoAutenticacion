using ForoAutenticacion.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ForoAutenticacion.Models  // Asegúrate de usar el mismo namespace de tus modelos
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post>? Posts { get; set; }  // Relación uno a muchos: un usuario puede tener muchos posts
    }
}

