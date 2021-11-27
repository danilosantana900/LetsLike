using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LetsLike.Configurations
{
    public class UsuarioLikeProjetoConfiguration : IEntityTypeConfiguration<UsuarioLikeProjeto>
    {
        public void Configure(EntityTypeBuilder<UsuarioLikeProjeto> builder)
        {            
            builder.HasKey(x => x.Id);
                     
            builder.HasOne(p => p.UsuarioLike)
                .WithMany(b => b.UsuarioLikeProjeto)
                .HasForeignKey(p => p.IdUsuarioLike)            
                .HasConstraintName("FK_USUARIO_USUARIO_LIKE_PROJETO");
                        
            builder.HasOne(p => p.ProjetoLike)
                .WithMany(b => b.ProjetoLikeUsuario)
                .HasForeignKey(p => p.IdProjetoLike)
                .HasConstraintName("FK_PROJETO_USUARIO_LIKE_PROJETO");
        }
    }
}
