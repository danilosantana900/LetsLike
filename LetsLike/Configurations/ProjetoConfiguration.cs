using LetsLike.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsLike.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(fk => fk.UsuarioCadastro)
                .WithMany(fk => fk.Projeto)
                .HasForeignKey(fk => fk.IdUsuarioCadastro)
                .HasConstraintName("FK_PROJETO_USUARIO_ID");
        }
    }
}
