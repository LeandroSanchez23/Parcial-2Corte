using Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cuota : Entity<int>
    {
        public double ValorCuota { get; set; }
        public DateTime FechaDePago { get; set; }

        public Cuota()
        {
        }

        public Cuota(double valorCuota, DateTime fechaDePago)
        {
            ValorCuota = valorCuota;
            FechaDePago = fechaDePago;
        }
    }
}
