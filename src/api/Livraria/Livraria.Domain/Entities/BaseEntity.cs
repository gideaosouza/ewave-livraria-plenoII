using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual bool Habilitado { get;  set; }
    }
}
