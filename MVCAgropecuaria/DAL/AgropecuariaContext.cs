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
        public DbSet<Roles> Rols { set; get; }
        public DbSet<Cargos> Cargos { set; get; }
        public DbSet<Usuarios> Usuarios { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Persona>()
                .HasOptional(p => p.PersonaModifico)
                .WithMany().HasForeignKey(p => p.IdPerMod);
        }


    }
}