using LetsLike.Data;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LetsLike.Services
{
    public class UsuarioLikeProjetoService : IUsuarioLikeProjetoService
    {
        private readonly LetsLikeContext _context;
        
        public UsuarioLikeProjetoService(LetsLikeContext context)
        {
            _context = context;
        }

        public UsuarioLikeProjeto SaveOrUpdate(UsuarioLikeProjeto model)
        {
            try
            {
                var state = model.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.Entry(model).State = state;
                _context.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public UsuarioLikeProjeto VerifyLike(int idProjeto, int idUsuario)
        {
            var response = _context.UsuariosLikeProjetos.Where(x =>
                x.IdProjetoLike.Equals(idProjeto) && 
                x.IdUsuarioLike.Equals(idUsuario)).FirstOrDefault();

            return response;
        }
    }
}