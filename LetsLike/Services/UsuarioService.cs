using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using LetsLike.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LetsLike.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly LetsLikeContext _context;

        public UsuarioService(LetsLikeContext context)
        {
            _context = context;
        }
        
        public IList<Usuario> FindAll()
        {
            var result = _context.Usuarios.Include(x => x.Projeto)
                            .ThenInclude(j => j.UsuarioCadastro)
                            .ToList();

            foreach (var item in result)
            {
                item.Senha = Senha.Descriptografar(item.Senha);
            }

            return result;
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
        }

        public IList<Usuario> FindByName(string nome)
        {
            return _context.Usuarios.Where(x => x.Nome == nome).ToList();
        }

        public Usuario FindByUserName(string userName)
        {
            return _context.Usuarios.Where(x => x.Username == userName).FirstOrDefault();
        }

        public bool VerifyPassword(string senha, int idUsuario)
        {
            try
            {
                var find = _context.Usuarios.Where(x => x.Id == idUsuario).FirstOrDefault();

                if (find != null)
                {
                    var senhaDB = Senha.Descriptografar(find.Senha);

                    return senhaDB.Equals(senha);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
