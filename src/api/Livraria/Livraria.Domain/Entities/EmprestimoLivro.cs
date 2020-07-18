using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class EmprestimoLivro :BaseEntity 
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public bool Devolvido { get; set; }
    }
}
