namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "OC", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "OC");
        }
    }
}
