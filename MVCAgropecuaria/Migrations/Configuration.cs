namespace MVCAgropecuaria.Migrations
{
    using Bogus;
    using MVCAgropecuaria.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCAgropecuaria.DAL.AgropecuariaContext>
    {
        int ROW_COUNT = 5;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCAgropecuaria.DAL.AgropecuariaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            SeedCargos(context);
            SeedRoles(context);
            //
            SeedPersonas(context);
            SeedUsuarios(context);


        }
        public void SeedPersonas(MVCAgropecuaria.DAL.AgropecuariaContext context)
        {
            int ROW_COUNT = 5;
            var testPersonas = new Faker<Persona>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nombres, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(p => p.Apellidos, (f, p) => f.Name.LastName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(p => p.Sexo, f => f.PickRandomParam(new string[] { "masculino", "femenino" }))
                .RuleFor(p => p.CI, f => f.Random.Number(99999999).ToString())
                .RuleFor(p => p.FechaIngreso, f => f.Date.Past())
                .RuleFor(p => p.FechaNacimiento, f => f.Date.Future())
                .RuleFor(p => p.FechaModificacion, f => f.Date.Future())
                .RuleFor(p => p.FechaRegistro, f => f.Date.Future())
                .RuleFor(p => p.Habilitado, f => f.PickRandomParam(new Boolean[] { true, false }))
                .RuleFor(p => p.Cargo, f => f.PickRandomParam(context.Cargos.ToArray()))
                .RuleFor(p => p.Telefonos, f => f.Phone.PhoneNumber().ToString())
                .RuleFor(p => p.TelefonoReferencia, f => f.Phone.PhoneNumber().ToString())
                .RuleFor(p => p.Domicilio, f => f.Address.FullAddress())
                .RuleFor(p => p.IdParentesco, f => f.Random.Number(ROW_COUNT))
                //.RuleFor(p => p.IdPerReg, f => f.Random.Number(ROW_COUNT))
                //.RuleFor(p => p.IdPerMod, f => f.Random.Number(ROW_COUNT))
                .RuleFor(p => p.PersonaReferencia, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male));
            var Personas = testPersonas.Generate(ROW_COUNT);
            Personas.ForEach(s => context.Personas.Add(s));
            context.SaveChanges();
        }

        public void SeedRoles(MVCAgropecuaria.DAL.AgropecuariaContext context)
        {
            var roles = new List<Roles>
            {
                new Roles{Id=1
                    ,Descripcion="Administrador"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                },
                new Roles{Id=1, Descripcion="Invitado"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                },
                new Roles{Id=1, Descripcion="Creador de Recursos"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                }
            };

            roles.ForEach(s => context.Rols.Add(s));
            context.SaveChanges();
        }
        public void SeedCargos(MVCAgropecuaria.DAL.AgropecuariaContext context)
        {
            var Cargos = new List<Cargos>
            {
                new Cargos{Id=1
                    ,Descripcion="Gerente"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                },
                new Cargos{Id=1, Descripcion="CEO"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                },
                new Cargos{Id=1, Descripcion="Adm Recursos Humanos"
                    ,Habilitado=true
                    ,FechaRegistro =DateTime.Parse("2005-09-01")
                    ,FechaModificacion =DateTime.Parse("2005-09-01")
                }
            };

            Cargos.ForEach(s => context.Cargos.Add(s));
            context.SaveChanges();
        }
        public void SeedUsuarios(MVCAgropecuaria.DAL.AgropecuariaContext context)
        {
            var testUsuarios = new Faker<Usuarios>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.UserName, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(p => p.Password, (f, p) => f.Internet.Password())
                .RuleFor(p => p.FechaModificacion, f => f.Date.Future())
                .RuleFor(p => p.FechaRegistro, f => f.Date.Future())
                .RuleFor(p => p.Habilitado, f => f.PickRandomParam(new Boolean[] { true, false }))
                .RuleFor(p => p.Persona, f => f.PickRandomParam(context.Personas.ToArray()))
                .RuleFor(p => p.Rol, f => f.PickRandomParam(context.Rols.ToArray()));

            var Usuarios = testUsuarios.Generate(2);
            Usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}
