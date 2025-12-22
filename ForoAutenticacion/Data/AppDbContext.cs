using ForoAutenticacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ForoAutenticacion.Models; // Cambia 'ForoAutenticacion' por tu namespace real si es distinto


namespace ForoAutenticacion.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // 👈 MUY importante

            // Si necesitas configurar algo extra:
            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

            // 🔥 NO pongas esto:
            // builder.Entity<ApplicationUser>().HasKey(u => u.Id); ❌
        }
    }
}


/*using ForoAutenticacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using ForoAutenticacion.Models;

namespace ForoAutenticacion.Data
{
  public class AppDbContext : IdentityDbContext<ApplicationUser>
  {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
      }
      public DbSet<Post> Posts { get; set; }

      // Esta línea solo es necesaria si necesitas consultar los usuarios desde la base de datos
     // public DbSet<ApplicationUser> ApplicationUsers { get; set; }

      // DbSets personalizados para tu foro
      protected override void OnModelCreating(ModelBuilder builder)
      {
          base.OnModelCreating(builder);

          // No pongas HasKey() sobre ApplicationUser
      }
  }
}  */
