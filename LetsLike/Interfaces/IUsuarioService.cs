using LetsLike.Models;
using System.Collections.Generic;

namespace LetsLike.Interfaces
{
    public interface IUsuarioService
    {
        Usuario SaveOrUpdate(Usuario usuario);

        IList<Usuario> FindAll();

        IList<Usuario> FindByName(string nome);

        IList<Usuario> FindByUserName(string userName);

        IList<Usuario> FindByEmail(string email);

        bool Login(Usuario usuario);
    }
}