using LetsLike.Models;

namespace LetsLike.Interfaces
{
    public interface IProjetoService
    {
        Projeto SaveOrUpdate(Projeto projeto);

        Projeto LikeProketo(UsuarioLikeProjeto like);
    }
}
