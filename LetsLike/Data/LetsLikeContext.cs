using LetsLike.Configurations;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsLike.Data
{
    public class LetsLikeContext : DbContext            
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<UsuarioLikeProjeto> UsuariosLikeProjetos { get; set; }

        public LetsLikeContext(DbContextOptions<LetsLikeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = @"Server=localhost\SQLEXPRESS;Database=LetsLike;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioLikeProjetoConfiguration());
        }
    }
}
