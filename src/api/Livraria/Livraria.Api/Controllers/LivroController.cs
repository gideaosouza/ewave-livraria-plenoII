using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application.Interfaces;
using Livraria.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Api.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService livroService;
        private readonly IUploadFileService uploadFileService;

        public LivroController(ILivroService livroService, IUploadFileService uploadFileService)
        {
            this.livroService = livroService;
            this.uploadFileService = uploadFileService;
        }

        /// <summary>
        /// Pode ser feito com Paginação
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
                return NotFound("Id não pode ser zero");
            }
            return Ok(livroService.Find(id).Result);
        }
        
        [HttpPost]
        public Task<Livro> Post(Livro obj)
        {
            return livroService.Insert(obj);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Livro obj)
        {
            if (id == 0)
            {
                Response.StatusCode = 400;
                return NotFound();
            }

            await livroService.Update(id, obj);
            return Ok();
        }

        [HttpGet("desabilitar/{idLivro}")]
        public async Task<IActionResult> Desabilitar(int idLivro)
        {
            var obj = livroService.Find(idLivro);
            await livroService.Desabilitar(obj.Result);
            return Ok();
        }
        
        [HttpGet("habilitar/{idLivro}")]
        public async Task<IActionResult> Habilitar(int idLivro)
        {
            var obj = livroService.Find(idLivro);
            await livroService.Habilitar(obj.Result);
            return Ok();
        }

        /// <summary>
        /// Esse metodo foi criado de maneira simples, apenas para atender um dos requisitos, caso tivesse mais tempo, faria-o por meio de uma entidade, fazer verificações de formato e tamanho..
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        [HttpPost("UploadCapa")]
        public async Task<IActionResult> UploadCapa([FromForm] IFormFile arquivo)
        {
            long size = arquivo.Length;
            var path = string.Empty;
            var format = arquivo.FileName.Split(".").LastOrDefault();

            if (arquivo.Length > 0 && !string.IsNullOrEmpty(format) && new string[] { "jpg", "png"}.Contains(format))
            {
                MemoryStream memoryStream = new MemoryStream();
                arquivo.CopyTo(memoryStream);
                path = uploadFileService.SaveFile(memoryStream, "capa", format);
            }

            if (string.IsNullOrEmpty(path))
                return BadRequest("Não foi possível processar a sua imagem");

            return Ok(new { path, size });
        }
    }
}