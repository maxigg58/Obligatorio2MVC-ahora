namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotaciones : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Password", c => c.String(nullable: false));
        }
    }
}
