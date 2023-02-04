using ExoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoApi.Contexts
{
    public class ExoApiContext: DbContext
    {
        public ExoApiContext()
        {

        }
        public ExoApiContext(DbContextOptions<ExoApiContext> options):base (options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-011IHATC\\SQLEXPRESS; initial catalog = ExoApi; Integrated Security = true; TrustServerCertificate = True");
            }
        }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
