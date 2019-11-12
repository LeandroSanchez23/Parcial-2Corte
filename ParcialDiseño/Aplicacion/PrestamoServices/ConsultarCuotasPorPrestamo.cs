using Dominio;
using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.PrestamoServices
{
    public class ConsultarCuotasPorPrestamo
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarCuotasPorPrestamo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Cuota> Ejecutar(string codigo) {
            var prestamo = _unitOfWork.PrestamoRepository.ConsultarPrestamo(p => p.Codigo == codigo);
            if (prestamo == null) {
                return new List<Cuota>();
            }
            return prestamo.Cuotas;
        }
    }
}
