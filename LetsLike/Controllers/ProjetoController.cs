﻿using AutoMapper;
using LetsLike.DTO;
using LetsLike.Interfaces;
using LetsLike.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetsLike.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoService projetoService, IMapper mapper)
        {
            _projetoService = projetoService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjetoDto> Post([FromBody] ProjetoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new Projeto
            {
                Nome = value.Nome,
                URL = value.URL,
                Imagem = value.Imagem,
                IdUsuarioCadastro = value.IdUsuarioCadastro,
                LikeContador = 0,
            };

            var salvarProjeto = _projetoService.SaveOrUpdate(model);

            if (salvarProjeto != null)
            {                
                return Ok(salvarProjeto);
            }
            else
            {
                object res = null;
                NotFoundObjectResult notfound = new NotFoundObjectResult(res);
                notfound.StatusCode = 400;
                notfound.Value = "Erro ao cadastrar o Projeto";

                return NotFound(notfound);
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjetoDto> Patch([FromBody] ProjetoDto value)
        {
            // TODO inserir o LIKEDOPROJETO 
            // quando ele disparar o método de LIKE que deverá ser construido
            // dentro da service de projeto

            return Ok();
        }
    }
}
