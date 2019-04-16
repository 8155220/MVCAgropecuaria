namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agro1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rol", "IdPerReg", c => c.Int());
            AddColumn("dbo.Rol", "IdPerMod", c => c.Int());
            CreateIndex("dbo.Rol", "IdPerReg");
            CreateIndex("dbo.Rol", "IdPerMod");
            AddForeignKey("dbo.Rol", "IdPerMod", "dbo.Persona", "Id");
            AddForeignKey("dbo.Rol", "IdPerReg", "dbo.Persona", "Id");
            DropColumn("dbo.Rol", "PersonaRegistroID");
            DropColumn("dbo.Rol", "PersonaModificoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rol", "PersonaModificoID", c => c.Int());
            AddColumn("dbo.Rol", "PersonaRegistroID", c => c.Int());
            DropForeignKey("dbo.Rol", "IdPerReg", "dbo.Persona");
            DropForeignKey("dbo.Rol", "IdPerMod", "dbo.Persona");
            DropIndex("dbo.Rol", new[] { "IdPerMod" });
            DropIndex("dbo.Rol", new[] { "IdPerReg" });
            DropColumn("dbo.Rol", "IdPerMod");
            DropColumn("dbo.Rol", "IdPerReg");
        }
    }
}
