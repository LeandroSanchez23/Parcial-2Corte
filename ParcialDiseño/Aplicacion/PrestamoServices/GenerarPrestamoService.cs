using Dominio;
using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.PrestamoServices
{
    public class GenerarPrestamoService
    {
        readonly IUnitOfWork _unitOfWork;

        public GenerarPrestamoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public GenerarPrestamoResponse Ejecutar(GenerarPrestamoRequest request)
        {
            var prestamo = _unitOfWork.PrestamoRepository.FindFirstOrDefault(t => t.Codigo == request.Codigo);
            if (prestamo == null)
            {
                DateTime fecha = DateTime.Parse(request.FechaPrestamo);
                prestamo = new Prestamo(request.Codigo,request.Cedula ,request.ValorPrestamo, request.PlazoNumeroMeses, fecha);
                var respuestaPrestamo = prestamo.GenerarPrestamo();
                if (respuestaPrestamo.IsError)
                {
                    return new GenerarPrestamoResponse() { Mensaje = respuestaPrestamo.Respuesta, IsError = true };
                }
                else
                {
                    _unitOfWork.PrestamoRepository.Add(prestamo);
                    _unitOfWork.Commit();
                    return new GenerarPrestamoResponse() { Mensaje = respuestaPrestamo.Respuesta, IsError=false };

                }
                
            }
            else
            {
                return new GenerarPrestamoResponse() { Mensaje = "Error el prestamo ya existe", IsError = true };
            }
        }

    }

    public class GenerarPrestamoRequest
    {
        public string Codigo { get; set; }
        public string Cedula { get; set; }
        public Double ValorPrestamo { get; set; }
        public Double PlazoNumeroMeses { get; set; }
        public String FechaPrestamo { get; set; }
       
    }
    public class GenerarPrestamoResponse
    {
        public bool IsError { get; set; } = false;
        public string Mensaje { get; set; }
    }
}
