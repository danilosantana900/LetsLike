using AutoMapper;
using LetsLike.DTO;
using LetsLike.Interfaces;
using LetsLike.Models;
using LetsLike.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicyLetsCode")]
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
        /// Exemplo:
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
        public ActionResult<UsuarioDto> Post([FromBody] UsuarioDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioMesmoUsername = _usuarioService.FindByUserName(value.Username);

            if (usuarioMesmoUsername != null)
                return BadRequest("Username não está disponivel!");
            
            var usuario = new Usuario
            {
                Nome = value.Nome,
                Username = value.Username,
                Email = value.Email,
                Senha = Senha.Criptografar(value.Senha),
            };

            var response = _usuarioService.SaveOrUpdate(usuario);

            if (response != null)
            {
                response.Senha = Senha.Descriptografar(response.Senha);
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

        // GET api/usuarios
        /// <summary>
        /// Retorna todos os usúarios na base
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET api/usuario
        ///     { 
        ///        "nome": "Maria da Silva",
        ///        "email": "mariasilva@provedor.com",
        ///        "username": "mariasilva",
        ///        "senha": "silva123",        
        ///        "projetos: [
        ///        
        ///        ]
        ///        "usuarioLikeProjeto":[
        ///        
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Usuário inserido na base</returns>
        /// <response code="200">Retorna os usuários cadastrados na base</response>
        /// <response code="404">Retorna se  usuario não for encontrado</response>
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