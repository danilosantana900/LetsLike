using LetsLike.Models;

namespace LetsLike.Interfaces
{
    public interface IUsuarioLikeProjetoService
    {
        UsuarioLikeProjeto SaveOrUpdate(UsuarioLikeProjeto model);
        UsuarioLikeProjeto VerifyLike(int idProjeto, int idUsuario);
    }
}
