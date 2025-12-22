using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForoAutenticacion.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Contenido { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con el usuario
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public string? CreadoPor { get; set; }

    }
}
