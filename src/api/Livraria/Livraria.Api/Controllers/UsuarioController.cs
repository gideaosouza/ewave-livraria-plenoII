using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// **Se der tempo, refazer com paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<Usuario>> Get()
        {
            return usuarioService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound("Id não pode ser zero");
            }
            return Ok(usuarioService.Find(id).Result);
        }
        [HttpPost]
        public Task<Usuario> Post(Usuario obj)
        {
            return usuarioService.Insert(obj);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            usuarioService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idUsuario}")]
        public Task Desabilitar(int idUsuario)
        {
            var obj = usuarioService.Find(idUsuario);
            return usuarioService.Desabilitar(obj.Result);
        }
        [HttpGet("habilitar/{idUsuario}")]
        public Task Habilitar(int idUsuario)
        {
            var obj = usuarioService.Find(idUsuario);
            return usuarioService.Habilitar(obj.Result);
        }
    }
}