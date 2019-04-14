namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agro4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "Persona_ID", "dbo.Persona");
            DropIndex("dbo.Usuario", new[] { "Persona_ID" });
            RenameColumn(table: "dbo.Usuario", name: "Persona_ID", newName: "PersonaID");
            AlterColumn("dbo.Usuario", "PersonaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "PersonaID");
            AddForeignKey("dbo.Usuario", "PersonaID", "dbo.Persona", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "PersonaID", "dbo.Persona");
            DropIndex("dbo.Usuario", new[] { "PersonaID" });
            AlterColumn("dbo.Usuario", "PersonaID", c => c.Int());
            RenameColumn(table: "dbo.Usuario", name: "PersonaID", newName: "Persona_ID");
            CreateIndex("dbo.Usuario", "Persona_ID");
            AddForeignKey("dbo.Usuario", "Persona_ID", "dbo.Persona", "ID");
        }
    }
}
