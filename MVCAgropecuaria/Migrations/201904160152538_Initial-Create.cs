namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
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
                .ForeignKey("dbo.Cargo", t => t.Cargo_Id)
                .ForeignKey("dbo.Persona", t => t.IdPerMod)
                .ForeignKey("dbo.Persona", t => t.IdPerReg)
                .Index(t => t.IdPerReg)
                .Index(t => t.IdPerMod)
                .Index(t => t.Cargo_Id);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        PersonaRegistroID = c.Int(),
                        PersonaModificoID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Usuario",
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
                .ForeignKey("dbo.Rol", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdPersona)
                .Index(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropForeignKey("dbo.Usuario", "IdPersona", "dbo.Persona");
            DropForeignKey("dbo.Cargo", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Cargo", "IdPerMod", "dbo.Persona");
            DropForeignKey("dbo.Persona", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Persona", "IdPerMod", "dbo.Persona");
            DropForeignKey("dbo.Persona", "Cargo_Id", "dbo.Cargo");
            DropIndex("dbo.Usuario", new[] { "IdRol" });
            DropIndex("dbo.Usuario", new[] { "IdPersona" });
            DropIndex("dbo.Persona", new[] { "Cargo_Id" });
            DropIndex("dbo.Persona", new[] { "IdPerMod" });
            DropIndex("dbo.Persona", new[] { "IdPerReg" });
            DropIndex("dbo.Cargo", new[] { "IdPerMod" });
            DropIndex("dbo.Cargo", new[] { "IdPerReg" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Rol");
            DropTable("dbo.Persona");
            DropTable("dbo.Cargo");
        }
    }
}
