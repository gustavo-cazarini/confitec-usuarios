using CONFITEC_USUARIOS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CONFITEC_USUARIOS_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
