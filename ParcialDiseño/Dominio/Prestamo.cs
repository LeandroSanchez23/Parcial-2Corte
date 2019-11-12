using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;


namespace Dominio
{
    public class Prestamo : Entity<int>
    {
        public String Codigo { get; private set; }
        public String Cedula { get; private set; }
        public double ValorPrestamo { get; private set; }
        public double PlazoNumeroMeses { get; private set; }
        public double ValorCuota { get; private set; }
        public double Saldo { get; private set; }
        public DateTime FechaPrestamo { get; set; }
        public List<Cuota> Cuotas { get; set; } = new List<Cuota>();

        public Prestamo(string codigo, string cedula, double valorPrestamo, double plazoNumeroMeses, DateTime fechaPrestamo)
        {
            Codigo = codigo;
            Cedula = cedula;
            ValorPrestamo = valorPrestamo;
            PlazoNumeroMeses = plazoNumeroMeses;
            Saldo = ValorPrestamo;
            ValorCuota = ValorPrestamo / PlazoNumeroMeses;
            FechaPrestamo = fechaPrestamo;
        }



        public RespuestaPrestamo GenerarPrestamo()
        {


            if (PlazoNumeroMeses > 12 || PlazoNumeroMeses <= 0)
            {
                return new RespuestaPrestamo() { Respuesta = "Plazo en meses invalido ", IsError = true };
            }
            else {
                
                DateTime fechaPago = FechaPrestamo;
               
                for (int i = 1; i <= PlazoNumeroMeses; i++)
                {
                    fechaPago = DateTime.Parse(fechaPago.AddMonths(1).ToString("d"));
                    Cuotas.Add(new Cuota(ValorCuota, fechaPago));

                }
                return new RespuestaPrestamo() { Respuesta = "Prestamo generado exitosamente"};

            }
        }

    }

    public class RespuestaPrestamo
    {
        public String Respuesta { get;  set; }
        public Boolean IsError { get;  set; } = false;

        
    }

    
}
