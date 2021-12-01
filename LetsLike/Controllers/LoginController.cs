using AutoMapper;
using LetsLike.DTO;
using LetsLike.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("ACorsPolicyLetsCode")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> Login([FromBody] LoginDto value)
        {
            const string msgNotFound = "Dados email/senha não conferem!";


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _usuarioService.FindByUserName(value.Username);

            if (user == null)
            {
                return NotFound(msgNotFound);
            }

            var verify = _usuarioService.VerifyPassword(value.Senha, user.Id);

            return verify ? Ok(verify) : NotFound(msgNotFound);            
        }
    }
}