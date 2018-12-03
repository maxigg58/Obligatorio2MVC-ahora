namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "Venta", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "Venta");
        }
    }
}
