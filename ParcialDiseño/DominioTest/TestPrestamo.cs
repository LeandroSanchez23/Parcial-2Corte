using Dominio;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DominioTest
{
    public class TestPrestamo
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GenerarPrestamoExitoso()
        {
            
            Prestamo prestamo = new Prestamo("Pre-01","1065",1000,5,DateTime.Parse("20-10-2019"));
            Boolean error = prestamo.GenerarPrestamo().IsError;
            /*
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine(prestamo.Cuotas[i].FechaDePago);
            }
            */
            Assert.AreEqual(error,false);
        }

        [Test]
        public void GenerarPrestamoErroneoMesesSeuperior()
        {

            Prestamo prestamo = new Prestamo("Pre-01", "1065", 1000, 13, DateTime.Parse("20-10-2019"));

            Assert.AreEqual(prestamo.GenerarPrestamo().IsError, true);
        }

        [Test]
        public void GenerarPrestamoErroneoMesesInferior()
        {

            Prestamo prestamo = new Prestamo("Pre-01", "1065", 1000, -3, DateTime.Parse("20-10-2019"));

            Assert.AreEqual(prestamo.GenerarPrestamo().IsError, true);
        }
        [Test]
        public void ListaDeCuotaCorrecta()
        {

            Prestamo prestamo = new Prestamo("Pre-01", "1065", 1000, 10, DateTime.Parse("20-10-2019"));
            Boolean error = prestamo.GenerarPrestamo().IsError;
            Assert.AreEqual(prestamo.Cuotas.Count, 10);
        }

        [Test]
        public void ListaDeCuotaIncorrecta()
        {

            Prestamo prestamo = new Prestamo("Pre-01", "1065", 1000, 13, DateTime.Parse("20-10-2019"));
            Boolean error = prestamo.GenerarPrestamo().IsError;

            Assert.AreEqual(prestamo.Cuotas.Count, 0);
        }
    }
}
