namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "OrdenDeCompra", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "OrdenDeCompra");
        }
    }
}
