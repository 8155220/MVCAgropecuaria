namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agro1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cargo", "PersonaModifico_ID", "dbo.Persona");
            DropForeignKey("dbo.Cargo", "PersonaRegistro_ID", "dbo.Persona");
            DropForeignKey("dbo.Rol", "PersonaModifico_ID", "dbo.Persona");
            DropForeignKey("dbo.Rol", "PersonaRegistro_ID", "dbo.Persona");
            DropForeignKey("dbo.Usuario", "PersonaModifico_ID", "dbo.Persona");
            DropForeignKey("dbo.Usuario", "PersonaRegistro_ID", "dbo.Persona");
            DropIndex("dbo.Cargo", new[] { "PersonaModifico_ID" });
            DropIndex("dbo.Cargo", new[] { "PersonaRegistro_ID" });
            DropIndex("dbo.Rol", new[] { "PersonaModifico_ID" });
            DropIndex("dbo.Rol", new[] { "PersonaRegistro_ID" });
            DropIndex("dbo.Usuario", new[] { "PersonaModifico_ID" });
            DropIndex("dbo.Usuario", new[] { "PersonaRegistro_ID" });
            AddColumn("dbo.Cargo", "IdPersonaRegistro", c => c.Int(nullable: false));
            AddColumn("dbo.Cargo", "IdPersonaModifico", c => c.Int(nullable: false));
            AddColumn("dbo.Rol", "IdPersonaRegistro", c => c.Int(nullable: false));
            AddColumn("dbo.Rol", "IdPersonaModifico", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdPersonaRegistro", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdPersonaModifico", c => c.Int(nullable: false));
            DropColumn("dbo.Cargo", "PersonaModifico_ID");
            DropColumn("dbo.Cargo", "PersonaRegistro_ID");
            DropColumn("dbo.Rol", "PersonaModifico_ID");
            DropColumn("dbo.Rol", "PersonaRegistro_ID");
            DropColumn("dbo.Usuario", "PersonaModifico_ID");
            DropColumn("dbo.Usuario", "PersonaRegistro_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "PersonaRegistro_ID", c => c.Int());
            AddColumn("dbo.Usuario", "PersonaModifico_ID", c => c.Int());
            AddColumn("dbo.Rol", "PersonaRegistro_ID", c => c.Int());
            AddColumn("dbo.Rol", "PersonaModifico_ID", c => c.Int());
            AddColumn("dbo.Cargo", "PersonaRegistro_ID", c => c.Int());
            AddColumn("dbo.Cargo", "PersonaModifico_ID", c => c.Int());
            DropColumn("dbo.Usuario", "IdPersonaModifico");
            DropColumn("dbo.Usuario", "IdPersonaRegistro");
            DropColumn("dbo.Rol", "IdPersonaModifico");
            DropColumn("dbo.Rol", "IdPersonaRegistro");
            DropColumn("dbo.Cargo", "IdPersonaModifico");
            DropColumn("dbo.Cargo", "IdPersonaRegistro");
            CreateIndex("dbo.Usuario", "PersonaRegistro_ID");
            CreateIndex("dbo.Usuario", "PersonaModifico_ID");
            CreateIndex("dbo.Rol", "PersonaRegistro_ID");
            CreateIndex("dbo.Rol", "PersonaModifico_ID");
            CreateIndex("dbo.Cargo", "PersonaRegistro_ID");
            CreateIndex("dbo.Cargo", "PersonaModifico_ID");
            AddForeignKey("dbo.Usuario", "PersonaRegistro_ID", "dbo.Persona", "ID");
            AddForeignKey("dbo.Usuario", "PersonaModifico_ID", "dbo.Persona", "ID");
            AddForeignKey("dbo.Rol", "PersonaRegistro_ID", "dbo.Persona", "ID");
            AddForeignKey("dbo.Rol", "PersonaModifico_ID", "dbo.Persona", "ID");
            AddForeignKey("dbo.Cargo", "PersonaRegistro_ID", "dbo.Persona", "ID");
            AddForeignKey("dbo.Cargo", "PersonaModifico_ID", "dbo.Persona", "ID");
        }
    }
}
