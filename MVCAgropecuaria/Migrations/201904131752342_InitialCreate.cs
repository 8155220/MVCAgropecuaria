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
                "dbo.Persona",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Sexo = c.String(),
                        CI = c.String(),
                        FechaNacimiento = c.DateTime(nullable: true),
                        FechaIngreso = c.DateTime(nullable: true),
                        FechaRegistro = c.DateTime(nullable: true),
                        Habilitado = c.Boolean(nullable: false),
                        FechaModificacion = c.DateTime(nullable: true),
                        Domicilio = c.String(),
                        Telefonos = c.String(),
                        PersonaReferencia = c.String(),
                        IdParentesco = c.Int(nullable: true),
                        TelefonoReferencia = c.String(),
                        PersonaRegistroID = c.Int(),
                        PersonaModificoID = c.Int(),
                        Cargo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cargo", t => t.Cargo_ID)
                .ForeignKey("dbo.Persona", t => t.PersonaModificoID)
                .ForeignKey("dbo.Persona", t => t.PersonaRegistroID)
                .Index(t => t.PersonaRegistroID)
                .Index(t => t.PersonaModificoID)
                .Index(t => t.Cargo_ID);
            
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
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Habilitado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        PersonaRegistroID = c.Int(),
                        PersonaModificoID = c.Int(),
                        Persona_ID = c.Int(),
                        Rol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Persona", t => t.Persona_ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.Persona_ID)
                .Index(t => t.Rol_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.Usuario", "Persona_ID", "dbo.Persona");
            DropForeignKey("dbo.Persona", "PersonaRegistroID", "dbo.Persona");
            DropForeignKey("dbo.Persona", "PersonaModificoID", "dbo.Persona");
            DropForeignKey("dbo.Persona", "Cargo_ID", "dbo.Cargo");
            DropIndex("dbo.Usuario", new[] { "Rol_ID" });
            DropIndex("dbo.Usuario", new[] { "Persona_ID" });
            DropIndex("dbo.Persona", new[] { "Cargo_ID" });
            DropIndex("dbo.Persona", new[] { "PersonaModificoID" });
            DropIndex("dbo.Persona", new[] { "PersonaRegistroID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Rol");
            DropTable("dbo.Persona");
            DropTable("dbo.Cargo");
        }
    }
}
