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
    public class LivroController : ControllerBase
    {
        private readonly ILivroService livroService;

        public LivroController(ILivroService livroService)
        {
            this.livroService = livroService;
        }

        /// <summary>
        /// **Se der tempo, refazer com paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<Livro>> Get()
        {
            return livroService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }
            return Ok(livroService.Find(id).Result);
        }
        [HttpPost]
        public Task<Livro> Post(Livro obj)
        {
            return livroService.Insert(obj);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            livroService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idLivro}")]
        public Task Desabilitar(int idLivro)
        {
            var obj = livroService.Find(idLivro);
            return livroService.Desabilitar(obj.Result);
        }
        [HttpGet("habilitar/{idLivro}")]
        public Task Habilitar(int idLivro)
        {
            var obj = livroService.Find(idLivro);
            return livroService.Habilitar(obj.Result);
        }
    }
}