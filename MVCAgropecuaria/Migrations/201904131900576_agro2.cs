namespace MVCAgropecuaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agro2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "FechaNacimiento", c => c.DateTime());
            AlterColumn("dbo.Persona", "FechaIngreso", c => c.DateTime());
            AlterColumn("dbo.Persona", "FechaRegistro", c => c.DateTime());
            AlterColumn("dbo.Persona", "FechaModificacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "FechaModificacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Persona", "FechaRegistro", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Persona", "FechaIngreso", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Persona", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
    }
}
