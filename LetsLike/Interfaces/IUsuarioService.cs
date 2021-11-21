using LetsLike.Models;
using System.Collections.Generic;

namespace LetsLike.Interfaces
{
    public interface IUsuarioService
    {
        Usuario SaveOrUpdate(Usuario usuario);

        IList<Usuario> FindAll();
    }
}
