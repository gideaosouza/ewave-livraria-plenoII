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
    public class LivroReservaController : ControllerBase
    {
        private readonly ILivroReservaService livroReservaService;

        public LivroReservaController(ILivroReservaService livroReservaService)
        {
            this.livroReservaService = livroReservaService;
        }

        /// <summary>
        /// Pode ser feito com Paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<LivroReserva>> Get()
        {
            return livroReservaService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound("Id não pode ser zero");
            }
            return Ok(livroReservaService.Find(id).Result);
        }
        [HttpPost]
        public Task<LivroReserva> Post(LivroReserva obj)
        {
            return livroReservaService.Insert(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LivroReserva obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await livroReservaService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idLivroReserva}")]
        public async Task<IActionResult> Desabilitar(int idLivroReserva)
        {
            var obj = livroReservaService.Find(idLivroReserva);
            await livroReservaService.Desabilitar(obj.Result);
            return Ok();
        }
        [HttpGet("habilitar/{idLivroReserva}")]
        public async Task<IActionResult> Habilitar(int idLivroReserva)
        {
            var obj = livroReservaService.Find(idLivroReserva);
            await livroReservaService.Habilitar(obj.Result);
            return Ok();
        }
    }
}