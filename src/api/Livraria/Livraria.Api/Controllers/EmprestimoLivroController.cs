using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Livraria.Domain.Validations;
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
        /// Pode ser feito com Paginação
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

        /// <summary>
        /// O Melhor seria abstrair a validação de entidade com valor para outra camada
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public object Post(EmprestimoLivro obj)
        {
            EmprestimoLivroValidator validations = new EmprestimoLivroValidator();
            validations.RuleFor(c => c).Must(c => !emprestimoLivroService.UsuarioAtingiuLimiteEmprestimo(c.UsuarioId))
                .WithMessage("Usuário atingiu o limite de livros emprestados");
            var results = validations.Validate(obj);

            results.AddToModelState(ModelState, null);

            if (!ModelState.IsValid)
            { 
                return BadRequest(results.Errors);
            }
            return emprestimoLivroService.Insert(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmprestimoLivro obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await emprestimoLivroService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idEmprestimoLivro}")]
        public async Task<IActionResult> Desabilitar(int idEmprestimoLivro)
        {
            var obj = emprestimoLivroService.Find(idEmprestimoLivro);
            await emprestimoLivroService.Desabilitar(obj.Result);
            return Ok();
        }
        [HttpGet("habilitar/{idEmprestimoLivro}")]
        public async Task<IActionResult> Habilitar(int idEmprestimoLivro)
        {
            var obj = emprestimoLivroService.Find(idEmprestimoLivro);
            await emprestimoLivroService.Habilitar(obj.Result);
            return Ok();
        }
    }
}