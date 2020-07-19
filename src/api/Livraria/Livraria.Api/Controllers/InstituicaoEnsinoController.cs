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
    public class InstituicaoEnsinoController : ControllerBase
    {
        private readonly IInstituicaoEnsinoService instituicaoEnsinoService;

        public InstituicaoEnsinoController(IInstituicaoEnsinoService instituicaoEnsinoService)
        {
            this.instituicaoEnsinoService = instituicaoEnsinoService;
        }

        /// <summary>
        /// **Se der tempo, refazer com paginação
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<InstituicaoEnsino>> Get()
        {
            return instituicaoEnsinoService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }
            return Ok(instituicaoEnsinoService.Find(id).Result);
        }
        [HttpPost]
        public Task<InstituicaoEnsino> Post(InstituicaoEnsino obj)
        {
            return instituicaoEnsinoService.Insert(obj);
        }
        [HttpPut("{id}")]
        public  IActionResult Put(int id, InstituicaoEnsino obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }
            
            instituicaoEnsinoService.Update(id, obj);
            return Ok(); 
        }

        [HttpGet("desabilitar/{idInstituicaoEnsino}")]
        public Task Desabilitar(int idInstituicaoEnsino)
        {
            var obj = instituicaoEnsinoService.Find(idInstituicaoEnsino);
            return instituicaoEnsinoService.Desabilitar(obj.Result);
        }
        [HttpGet("habilitar/{idInstituicaoEnsino}")]
        public Task Habilitar(int idInstituicaoEnsino)
        {
            var obj = instituicaoEnsinoService.Find(idInstituicaoEnsino);
            return instituicaoEnsinoService.Habilitar(obj.Result);
        }
    }
}