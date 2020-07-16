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
        public Task<IEnumerable<InstituicaoEnsino>> Get()
        {
            return instituicaoEnsinoService.GetAll();
        }
    }
}