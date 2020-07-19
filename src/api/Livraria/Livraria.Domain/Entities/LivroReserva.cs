using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class LivroReserva : BaseEntity
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }
        public DateTime? DataResgate { get; set; }
    }
}
