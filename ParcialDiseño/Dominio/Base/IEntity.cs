using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
