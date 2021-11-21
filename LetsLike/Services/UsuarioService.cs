using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using System.Collections.Generic;
using System.Linq;

namespace LetsLike.Services
{
    public class UsuarioService : IUsuarioService
    {
        public LetsLikeContext _context;

        public UsuarioService(LetsLikeContext context)
        {
            _context = context;
        }
        
        public IList<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public IList<Usuario> FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).ToList();
        }

        public IList<Usuario> FindByName(string nome)
        {
            return _context.Usuarios.Where(x => x.Nome == nome).ToList();
        }

        public IList<Usuario> FindByUserName(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).ToList();
        }

        public Usuario SaveOrUpdate(Usuario usuario)
        {
            var exist = _context.Usuarios.Where(x => x.Id.Equals(usuario.Id)).FirstOrDefault();

            if (exist == null)
            {
                _context.Usuarios.Add(usuario);
            }
            else
            {
                exist.Nome = usuario.Nome;
                exist.Username = usuario.Username;
                exist.Senha = usuario.Senha;
                exist.Email = usuario.Email;
            }

            _context.SaveChanges();

            return usuario;
        }
    }
}
