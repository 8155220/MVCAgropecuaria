namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        IdPerReg = c.Int(),
                        IdPerMod = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.IdPerMod)
                .ForeignKey("dbo.Persona", t => t.IdPerReg)
                .Index(t => t.IdPerReg)
                .Index(t => t.IdPerMod);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Sexo = c.String(),
                        CI = c.String(),
                        FechaNacimiento = c.DateTime(),
                        FechaIngreso = c.DateTime(),
                        FechaRegistro = c.DateTime(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(),
                        Domicilio = c.String(),
                        Telefonos = c.String(),
                        PersonaReferencia = c.String(),
                        IdParentesco = c.Int(nullable: false),
                        TelefonoReferencia = c.String(),
                        IdPerReg = c.Int(),
                        IdPerMod = c.Int(),
                        Cargo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargos", t => t.Cargo_Id)
                .ForeignKey("dbo.Persona", t => t.IdPerMod)
                .ForeignKey("dbo.Persona", t => t.IdPerReg)
                .Index(t => t.IdPerReg)
                .Index(t => t.IdPerMod)
                .Index(t => t.Cargo_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        IdPerReg = c.Int(),
                        IdPerMod = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.IdPerMod)
                .ForeignKey("dbo.Persona", t => t.IdPerReg)
                .Index(t => t.IdPerReg)
                .Index(t => t.IdPerMod);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        IdPersona = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                        IdPerReg = c.Int(),
                        IdPerMod = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.IdPersona, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdPersona)
                .Index(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Roles");
            DropForeignKey("dbo.Usuarios", "IdPersona", "dbo.Persona");
            DropForeignKey("dbo.Roles", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Roles", "IdPerMod", "dbo.Persona");
            DropForeignKey("dbo.Cargos", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Cargos", "IdPerMod", "dbo.Persona");
            DropForeignKey("dbo.Persona", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Persona", "IdPerMod", "dbo.Persona");
            DropForeignKey("dbo.Persona", "Cargo_Id", "dbo.Cargos");
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Usuarios", new[] { "IdPersona" });
            DropIndex("dbo.Roles", new[] { "IdPerMod" });
            DropIndex("dbo.Roles", new[] { "IdPerReg" });
            DropIndex("dbo.Persona", new[] { "Cargo_Id" });
            DropIndex("dbo.Persona", new[] { "IdPerMod" });
            DropIndex("dbo.Persona", new[] { "IdPerReg" });
            DropIndex("dbo.Cargos", new[] { "IdPerMod" });
            DropIndex("dbo.Cargos", new[] { "IdPerReg" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
            DropTable("dbo.Persona");
            DropTable("dbo.Cargos");
        }
    }
}
