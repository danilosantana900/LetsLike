using AutoMapper;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public LoginController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // Post api/login
        /// <summary>
        ///     Valida usuário email/senha
        /// </summary>
        /// <returns>Usuários cadastrados na base de dados</returns>
        /// <response code="200">Se usuário email/senha estão corretos</response>
        /// <response code="404">Se email/senha não conferem</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Login([FromBody] Usuario value)
        {
            if (_usuarioService.Login(value))
            {
                return Ok("Usuário Cadastrado");
            }
            else
            {
                return NotFound("Dados email/senha não conferem");
            }
        }
    }
}
