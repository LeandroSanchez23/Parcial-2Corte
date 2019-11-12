using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.PrestamoServices;
using Dominio;
using Dominio.Contracts;
using Infraestructura;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterfazUsuario.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        readonly BancoContext _context;      
        readonly IUnitOfWork _unitofwork;

        public PrestamoController(BancoContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;    
        }

        [HttpPost("GenerarPrestamo")]
        public ActionResult<GenerarPrestamoResponse> GenerarPrestamo(GenerarPrestamoRequest request)
        {
            GenerarPrestamoService servicio = new GenerarPrestamoService(_unitofwork);
            var response = servicio.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet("ConsultarCuotasPorPrestamo")]
        public ActionResult<List<Cuota>> ConsultarCuotas(string codigo)
        {
            ConsultarCuotasPorPrestamo servicio = new ConsultarCuotasPorPrestamo(_unitofwork);
            var response = servicio.Ejecutar(codigo);
            return Ok(response);
        }
    }
}