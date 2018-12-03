namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Union2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "PrecioVentaSugerido", c => c.Int(nullable: false));
            AddColumn("dbo.Productoes", "tipoProducto", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "TiempoPreviso", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "CantMinimaAPedir", c => c.Int(nullable: false));
            DropColumn("dbo.Productoes", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Productoes", "CantMinimaAPedir", c => c.Int());
            AlterColumn("dbo.Productoes", "TiempoPreviso", c => c.Int());
            DropColumn("dbo.Productoes", "tipoProducto");
            DropColumn("dbo.Productoes", "PrecioVentaSugerido");
        }
    }
}
