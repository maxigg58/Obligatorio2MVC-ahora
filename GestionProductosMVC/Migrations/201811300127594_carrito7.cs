namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carritoes", "nomProd");
            DropColumn("dbo.Carritoes", "cantidad");
            DropColumn("dbo.Carritoes", "precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "precio", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "nomProd", c => c.String(nullable: false));
        }
    }
}
