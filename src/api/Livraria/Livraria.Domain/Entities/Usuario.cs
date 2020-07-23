using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public int InstituicaoEnsinoId { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
