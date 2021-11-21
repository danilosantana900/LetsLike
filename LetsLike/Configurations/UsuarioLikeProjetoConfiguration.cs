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
                     
            builder.HasOne(fk => fk.UsuarioLike)
                .WithMany(fk => fk.UsuarioLikeProjeto)
                .HasForeignKey(fk => fk.IdUsuarioLike)            
                .HasConstraintName("FK_USUARIO_USUARIO_LIKE_PROJETO");
                        
            builder.HasOne(fk => fk.ProjetoLike)
                .WithMany(fk => fk.ProjetoLikeUsuario)
                .HasForeignKey(fk => fk.IdProjetoLike)
                .HasConstraintName("FK_PROJETO_USUARIO_LIKE_PROJETO");
        }
    }
}
