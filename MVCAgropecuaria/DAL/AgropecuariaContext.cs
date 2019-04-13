using MVCAgropecuaria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.DAL
{
    public class AgropecuariaContext : DbContext
    {
        public AgropecuariaContext() : base("AgropecuariaContext"){}

        public DbSet<Persona> Personas { set; get; }
        public DbSet<Rol> Rols { set; get; }
        public DbSet<Cargo> Cargos { set; get; }
        public DbSet<Usuario> Usuarios { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}