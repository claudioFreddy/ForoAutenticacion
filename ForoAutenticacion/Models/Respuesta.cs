using ForoAutenticacion.Models;
//using ForoAutenticacion.Models;

namespace ForoAutenticacion.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public string? AutorEmail { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relación con el tema
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}

