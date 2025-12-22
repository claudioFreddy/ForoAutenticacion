using ForoAutenticacion.Models;

namespace ForoAutenticacion.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public string? AutorEmail { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public List<Respuesta> Respuestas { get; set; } = new();
    }
}

