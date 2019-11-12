using Aplicacion.PrestamoServices;
using Infraestructura;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AplicacionTest
{
    public class TestPrestamoAplicacion
    {
        BancoContext _context;
        UnitOfWork _unitOfWork;
        UnitOfWork _unitOfWorkBD;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;
            var optionsBD = new DbContextOptionsBuilder<BancoContext>().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BancoParcial;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

            _context = new BancoContext(optionsInMemory);
            _unitOfWork = new UnitOfWork(_context);
            _context = new BancoContext(optionsBD);
            _unitOfWorkBD = new UnitOfWork(_context);
        }

        [Test]
        public void GenerarPrestamoCorrecto()
        {
            GenerarPrestamoRequest request = new GenerarPrestamoRequest()
            {
                Codigo = "Pres-01",
                Cedula = "1065",
                ValorPrestamo = 10000,
                PlazoNumeroMeses = 5,
                FechaPrestamo = "20-10-2019"
                
            };
            var response = new GenerarPrestamoService(_unitOfWork).Ejecutar(request);
            Assert.AreEqual(response.IsError, false);
        }

        [Test]
        public void GenerarPrestamoIncorrecto()
        {

            GenerarPrestamoRequest request = new GenerarPrestamoRequest()
            {
                Codigo = "Pres-01",
                Cedula = "1065",
                ValorPrestamo = 10000,
                PlazoNumeroMeses = 5,
                FechaPrestamo = "20-10-2019"

            };
            var response = new GenerarPrestamoService(_unitOfWork).Ejecutar(request);
            Assert.AreEqual(response.IsError, true);
        }

        [Test]
        public void ConsultarCuotasPorPrestamoIncorrecto()
        {

            
            var response = new ConsultarCuotasPorPrestamo(_unitOfWorkBD).Ejecutar("Pre-02");
            Assert.AreEqual(response.Count, 0);
        }

        [Test]
        public void ConsultarCuotasPorPrestamoCorrecto()
        {

            var response = new ConsultarCuotasPorPrestamo(_unitOfWorkBD).Ejecutar("Pre-01");
            Assert.AreEqual(response.Count, 5);
        }
    }
}