using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public class Livro : BaseEntity
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public string Capa { get; set; }
    }
}
