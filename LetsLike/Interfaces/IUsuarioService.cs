using LetsLike.Models;
using System.Collections.Generic;

namespace LetsLike.Interfaces
{
    public interface IUsuarioService
    {
        Usuario SaveOrUpdate(Usuario usuario);

        IList<Usuario> FindAll();

        IList<Usuario> FindByName(string nome);

        Usuario FindByUserName(string userName);

        Usuario FindByEmail(string email);

        bool VerifyPassword(string senha, int idusuario);
    }
}