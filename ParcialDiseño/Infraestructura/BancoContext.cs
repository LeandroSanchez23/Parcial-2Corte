using Dominio;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura
{
    public class BancoContext : DbContextBase
    {
        public BancoContext(DbContextOptions options) : base(options)
        {

        }
        /*
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        */
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Cuota> Cuota { get; set; }

    }
}
