using LetsLike.Models;
using System.Collections.Generic;

namespace LetsLike.Interfaces
{
    public interface IProjetoService
    {
        Projeto SaveOrUpdate(Projeto projeto);
        int LikeProjeto(UsuarioLikeProjeto model);
        IList<Projeto> GetByUsuario(int idUsuario);
        IList<Projeto> GetAll();
    }
}
