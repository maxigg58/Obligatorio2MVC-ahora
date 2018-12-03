namespace GestionProductosMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrito5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Carrito_idSolicitud", c => c.Int());
            CreateIndex("dbo.Productoes", "Carrito_idSolicitud");
            AddForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes", "idSolicitud");
            DropColumn("dbo.Carritoes", "idProducto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "idProducto", c => c.Int(nullable: false));
            DropForeignKey("dbo.Productoes", "Carrito_idSolicitud", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_idSolicitud" });
            DropColumn("dbo.Productoes", "Carrito_idSolicitud");
        }
    }
}
