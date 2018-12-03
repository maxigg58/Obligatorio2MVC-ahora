namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "nomProd", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "nomProd");
        }
    }
}
