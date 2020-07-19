using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class InstituicaoEnsino : BaseEntity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPNJ { get; set; }
        public string Telefone { get; set; }
    }
}
