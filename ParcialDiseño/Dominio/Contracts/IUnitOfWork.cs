//using Dominio.Repositories;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        /*
        IProductoRepository ProductoRepository { get; }
        IIngredienteRepository IngredienteRepository { get; }
        */

        IPrestamoRepository PrestamoRepository { get; }

        int Commit();
    }
}
