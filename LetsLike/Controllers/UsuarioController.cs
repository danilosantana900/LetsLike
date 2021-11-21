using AutoMapper;
using LetsLike.DTO;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    // [Autorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // POST api/usuario
        /// <summary>
        ///     Cria um usuário na base de dados conforme informado no corpo da requisição
        /// </summary>
        /// <remarks>
        ///     Exemplo:
        ///
        ///     POST api/usuario
        ///     { 
        ///        "nome": "Maria da Silva",
        ///        "email": "mariasilva@provedor.com",
        ///        "username": "mariasilva",
        ///        "senha": "silva123",
        ///        "confirmaSenha": "silva123"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Usuário que foi inserido na base</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Usuario> Post([FromBody] UsuarioDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = value.Nome,
                Username = value.Username,
                Email = value.Email,
                Senha = value.Senha,
            };

            var response = _usuarioService.SaveOrUpdate(usuario);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao cadastrar o usuário";

                return NotFound(notfound);
            }
        }

        // GET api/usuario
        /// <summary>
        ///     Busca usuários na base de dados
        /// </summary>        
        /// <returns>Usuários cadastrados na base de dados</returns>
        /// <response code="200">Retorna lista de usuários</response>
        /// <response code="404">Se não possui cadastros</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var response = _usuarioService.FindAll();

            if (response != null)
            {
                return Ok(response.Select(x => _mapper.Map<Usuario>(x)).ToList());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
