using Dominio;
using Dominio.Repositories;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructura.Repositories
{
    
    public class PrestamoRepository : GenericRepository<Prestamo>, IPrestamoRepository
    {
        public PrestamoRepository(IDbContext context)
              : base(context)
        {

        }

        public Prestamo ConsultarPrestamo(Expression<Func<Prestamo, bool>> predicate)
        {
            Prestamo p = _dbset.Where(predicate).Include(p => p.Cuotas).ToList().FirstOrDefault();
            return p;
        }
    }
}
