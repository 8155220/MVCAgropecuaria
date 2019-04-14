namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agro5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "Rol_ID", "dbo.Rol");
            DropIndex("dbo.Usuario", new[] { "Rol_ID" });
            RenameColumn(table: "dbo.Usuario", name: "Rol_ID", newName: "RolID");
            AlterColumn("dbo.Usuario", "RolID", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "RolID");
            AddForeignKey("dbo.Usuario", "RolID", "dbo.Rol", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "RolID", "dbo.Rol");
            DropIndex("dbo.Usuario", new[] { "RolID" });
            AlterColumn("dbo.Usuario", "RolID", c => c.Int());
            RenameColumn(table: "dbo.Usuario", name: "RolID", newName: "Rol_ID");
            CreateIndex("dbo.Usuario", "Rol_ID");
            AddForeignKey("dbo.Usuario", "Rol_ID", "dbo.Rol", "ID");
        }
    }
}
