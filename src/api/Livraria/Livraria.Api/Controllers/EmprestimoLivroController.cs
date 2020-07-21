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
    public class EmprestimoLivroController : ControllerBase
    {
        private readonly ILivroEmprestimoService emprestimoLivroService;

        public EmprestimoLivroController(ILivroEmprestimoService emprestimoLivroService)
        {
            this.emprestimoLivroService = emprestimoLivroService;
        }

        /// <summary>
        /// **Se der tempo, refazer com paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<EmprestimoLivro>> Get()
        {
            return emprestimoLivroService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound("Id não pode ser zero");
            }
            return Ok(emprestimoLivroService.Find(id).Result);
        }
        [HttpPost]
        public Task<EmprestimoLivro> Post(EmprestimoLivro obj)
        {
            return emprestimoLivroService.Insert(obj);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, EmprestimoLivro obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            emprestimoLivroService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idEmprestimoLivro}")]
        public Task Desabilitar(int idEmprestimoLivro)
        {
            var obj = emprestimoLivroService.Find(idEmprestimoLivro);
            return emprestimoLivroService.Desabilitar(obj.Result);
        }
        [HttpGet("habilitar/{idEmprestimoLivro}")]
        public Task Habilitar(int idEmprestimoLivro)
        {
            var obj = emprestimoLivroService.Find(idEmprestimoLivro);
            return emprestimoLivroService.Habilitar(obj.Result);
        }
    }
}