namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_idSolicitud" });
            AddColumn("dbo.Carritoes", "idProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "nomProd", c => c.String(nullable: false));
            AddColumn("dbo.Carritoes", "cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Carritoes", "precio", c => c.Int(nullable: false));
            DropColumn("dbo.Carritoes", "OC");
            DropColumn("dbo.Productoes", "Carrito_idSolicitud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "Carrito_idSolicitud", c => c.Int());
            AddColumn("dbo.Carritoes", "OC", c => c.Int(nullable: false));
            DropColumn("dbo.Carritoes", "precio");
            DropColumn("dbo.Carritoes", "cantidad");
            DropColumn("dbo.Carritoes", "nomProd");
            DropColumn("dbo.Carritoes", "idProducto");
            CreateIndex("dbo.Productoes", "Carrito_idSolicitud");
            AddForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
        }
    }
}
