using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dominio.Repositories
{
    public interface IPrestamoRepository : IGenericRepository<Prestamo>
    {
        Prestamo ConsultarPrestamo(Expression<Func<Prestamo, bool>> predicate);
    }
}
