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
    [Route("api/[controller]")]
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